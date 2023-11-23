using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForms_Font_Swapper;
using System.Drawing.Text;

namespace WFS_Test_Program
{
    public partial class WFS_Test_Form : Form
    {
        // global variables
        // -stores all the program font families that were loaded into the program
        PrivateFontCollection programFonts = new PrivateFontCollection();
        // font loaded from resources
        Font testFont = null;

        // stores the font family to replace (when user clicks the 'Replace Fonts from Font Family:' button)
        // -populated from dialog when user clicks pickFontFamilyBtn.
        FontFamily fontFamilyToReplace = null;

        // stores the font to replace (when user clicks the 'Replace Specific Font:' button)
        // -populated from dialog when user clicks pickSpecificFontBtn.
        Font fontToReplace = null;

        public WFS_Test_Form()
        {
            InitializeComponent();

            // declare local variables
            string errorMessage = "";

            // load in font
            loadFontByteArrayToCollection(ref programFonts, Properties.Resources.ShareTechMono_Regular, out errorMessage);
            testFont = new System.Drawing.Font(programFonts.Families[0], 15f, FontStyle.Regular);

            // scan form for fonts
            WinFormsFontSwapper.scanFormForFonts(this);
        }

        // adds fonts from a resource
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        public static bool loadFontByteArrayToCollection(ref PrivateFontCollection fontCollectionContainer,
            byte[] fontData, out string errorMessage)
        {
            // errors with parameters (fontCollectionContainer null or fontData null)
            #region CHECK FOR ERRORS

            // check for fontCollectionContainer being null
            if (fontCollectionContainer == null)
            {
                errorMessage = "Error! Font collection container is null, can't proceed.";
                return false;
            }

            // check for fontData being null
            if (fontData == null)
            {
                errorMessage = "Error! Font data is null, can't proceed.";
                return false;
            }

            #endregion

            // source: https://stackoverflow.com/a/23519499

            // need to allocate a block of memory and know the start of it (have pointer to start of it) since system function requires it
            // -pointer to start of font data array (required by AddFontMemResourceEx)
            IntPtr fontResourcePointer = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            // copy data from font data array into buffer designated for task (required by AddFontMemResourceEx)
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontResourcePointer, fontData.Length);

            // try load font into collection
            try
            {
                // using system function, load font into font collection from allocated memory block
                fontCollectionContainer.AddMemoryFont(fontResourcePointer, fontData.Length);
            }
            catch (Exception e)
            {
                // return error message and false
                errorMessage = "Unable to load font into collection, exception is as follows: " + Environment.NewLine +
                    Environment.NewLine + e.ToString();
                return false;
            }

            // free memory used to create buffer with known starting location (pointer) since it's no longer needed
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontResourcePointer);

            // return result, blank error message since if this point was reached, success
            errorMessage = "";
            return true;
        }

        #region UNDO FONT CHANGES

        private void undoFontChangesBtn(object sender, EventArgs e)
        {
            // undo font changes
            WinFormsFontSwapper.resetFontChanges();
            // clear replacement fonts
            WinFormsFontSwapper.clearReplacementFonts();
            this.Refresh();
        }

        #endregion

        #region APPLY UNIVERSAL FONT

        private void setUniversalFontBtn(object sender, EventArgs e)
        {
            // undo changes
            undoFontChangesBtn(null, null);

            //set universal font
            WinFormsFontSwapper.specifyUniversalFont(programFonts.Families[0]);
            // apply font changes
            WinFormsFontSwapper.applyFontChanges();
            // refresh to apply changes
            this.Refresh();
        }

        #endregion

        #region REPLACE FONTS OF SPECIFIC SIZE BUTTON

        private void replaceFontsSizeBtn_Click(object sender, EventArgs e)
        {
            // undo changes
            undoFontChangesBtn(null, null);

            // declare local variables
            float parsedFontSize = (float)fontSizeReplaceBox.Value;

            // proceed with changes
            WinFormsFontSwapper.specifyFontForSize(programFonts.Families[0], null, parsedFontSize);
            // apply font changes
            WinFormsFontSwapper.applyFontChanges();
            // refresh to apply changes
            this.Refresh();
        }

        #endregion

        #region REPLACE FONTS OF SIZE RANGE

        private void replaceFontsWithinSizeRangeBtn_Click(object sender, EventArgs e)
        {
            // undo changes
            undoFontChangesBtn(null, null);

            // declare local variables
            float rangeMinimum = (float)minFontSizeReplaceUD.Value;
            float rangeMaximum = (float)maxFontSizeReplaceUD.Value;

            // proceed with changes
            WinFormsFontSwapper.specifyFontForSizeRange(programFonts.Families[0], null, rangeMinimum, rangeMaximum);
            // apply font changes
            WinFormsFontSwapper.applyFontChanges();
            // refresh to apply changes
            this.Refresh();
        }

        #endregion

        #region REPLACE FONT FAMILY

        private void replaceFontFamilyBtn_Click(object sender, EventArgs e)
        {
            // undo changes
            undoFontChangesBtn(null, null);

            // ensure that font family to be replaced isn't null
            if (fontFamilyToReplace == null)
            {
                // display error message
                MessageBox.Show("Error! No font family picked yet. To pick, click the 'Pick Font Family' button and select a font.");
                // return since can't proceed
                return;
            }

            // proceed with changes
            WinFormsFontSwapper.specifyFontForFontFamily(programFonts.Families[0], null, fontFamilyToReplace.Name);
            // apply font changes
            WinFormsFontSwapper.applyFontChanges();
            // refresh to apply changes
            this.Refresh();
        }

        private void pickFontFamilyBtn_Click(object sender, EventArgs e)
        {
            // show font dialog
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // store font family in fontFamilyToReplace variable
                this.fontFamilyToReplace = fontDialog1.Font.FontFamily;

                // populate font family name
                fontFamilyToReplaceTB.Text = fontDialog1.Font.FontFamily.Name;
            }
        }

        #endregion

        #region REPLACE SPECIFIC FONT

        private void replaceSpecificFontBtn_Click(object sender, EventArgs e)
        {
            // undo changes
            undoFontChangesBtn(null, null);

            // ensure that font to be replaced isn't null
            if (fontToReplace == null)
            {
                // display error message
                MessageBox.Show("Error! No font picked yet. To pick, click the 'Pick Font' button and select a font.");
                // return since can't proceed
                return;
            }

            // recreate test font to match the size and style of the font it replaes
            // (this is optional of course)
            testFont = new System.Drawing.Font(testFont.FontFamily, fontToReplace.Size, fontToReplace.Style);

            // proceed with changes
            WinFormsFontSwapper.specifyFontForFont(testFont, fontToReplace.Name, fontToReplace.Size, fontToReplace.Style);
            // apply font changes
            WinFormsFontSwapper.applyFontChanges();
            // refresh to apply changes
            this.Refresh();
        }

        private void pickSpecificFontBtn_Click(object sender, EventArgs e)
        {
            // show font dialog
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // store font family in fontFamilyToReplace variable
                this.fontToReplace = fontDialog1.Font;

                // populate font family name
                fontToReplaceTB.Text = fontDialog1.Font.ToString();
            }
        }

        #endregion

        private void replacementFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // display the replacement font's name and license
            MessageBox.Show(@"Copyright (c) 2012, Carrois Type Design, Ralph du Carrois (post@carrois.com www.carrois.com), with Reserved Font Name 'Share'
This Font Software is licensed under the SIL Open Font License, Version 1.1. This license is copied below, and is also available with a FAQ at: http://scripts.sil.org/OFL


-----------------------------------------------------------
SIL OPEN FONT LICENSE Version 1.1 - 26 February 2007
-----------------------------------------------------------

PREAMBLE
The goals of the Open Font License (OFL) are to stimulate worldwide development of collaborative font projects, to support the font creation efforts of academic and linguistic communities, and to provide a free and open framework in which fonts may be shared and improved in partnership with others.

The OFL allows the licensed fonts to be used, studied, modified and redistributed freely as long as they are not sold by themselves. The fonts, including any derivative works, can be bundled, embedded,  redistributed and/or sold with any software provided that any reserved names are not used by derivative works. The fonts and derivatives, however, cannot be released under any other type of license. The requirement for fonts to remain under this license does not apply to any document created using the fonts or their derivatives.

DEFINITIONS
'Font Software' refers to the set of files released by the Copyright Holder(s) under this license and clearly marked as such. This may include source files, build scripts and documentation.

'Reserved Font Name' refers to any names specified as such after the copyright statement(s).

'Original Version' refers to the collection of Font Software components as distributed by the Copyright Holder(s).

'Modified Version' refers to any derivative made by adding to, deleting, or substituting -- in part or in whole -- any of the components of the Original Version, by changing formats or by porting the Font Software to a new environment.

'Author' refers to any designer, engineer, programmer, technical writer or other person who contributed to the Font Software.

PERMISSION & CONDITIONS
Permission is hereby granted, free of charge, to any person obtaining a copy of the Font Software, to use, study, copy, merge, embed, modify, redistribute, and sell modified and unmodified copies of the Font Software, subject to the following conditions:

1) Neither the Font Software nor any of its individual components, in Original or Modified Versions, may be sold by itself.

2) Original or Modified Versions of the Font Software may be bundled, redistributed and/or sold with any software, provided that each copy contains the above copyright notice and this license. These can be included either as stand-alone text files, human-readable headers or in the appropriate machine-readable metadata fields within text or binary files as long as those fields can be easily viewed by the user.

3) No Modified Version of the Font Software may use the Reserved Font Name(s) unless explicit written permission is granted by the corresponding Copyright Holder. This restriction only applies to the primary font name as presented to the users.

4) The name(s) of the Copyright Holder(s) or the Author(s) of the Font Software shall not be used to promote, endorse or advertise any Modified Version, except to acknowledge the contribution(s) of the Copyright Holder(s) and the Author(s) or with their explicit written permission.

5) The Font Software, modified or unmodified, in part or in whole, must be distributed entirely under this license, and must not be distributed under any other license. The requirement for fonts to remain under this license does not apply to any document created using the Font Software.

TERMINATION
This license becomes null and void if any of the above conditions are not met.

DISCLAIMER
THE FONT SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT OF COPYRIGHT, PATENT, TRADEMARK, OR OTHER RIGHT. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, INCLUDING ANY GENERAL, SPECIAL, INDIRECT, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF THE USE OR INABILITY TO USE THE FONT SOFTWARE OR FROM OTHER DEALINGS IN THE FONT SOFTWARE.
"
                , "Replacement Font (ShareTechMono_Regular) license");
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Jacob Micallef on November 23, 2023." + Environment.NewLine + Environment.NewLine
                + @"﻿MIT License

Copyright (c) 2023 Jacob Micallef

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'), to deal in the Software without restriction, including without limitation the rightsnto use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.", "About Program");
        }
    }
}
