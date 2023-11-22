/* 
MIT License

Copyright (c) 2023 Jacob Micallef

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WinForms_Font_Swapper
{
    /// <summary>
    /// A class designed to make swapping fonts in a windows form program easier.
    /// </summary>
    public static class WinFormsFontSwapper
    {
        // NOTE:
        // ***Custom fonts WILL NOT render unless you add Application.SetCompatibleTextRenderingDefault(true); to the
        // Main function in Program.cs.***
        // -Source: https://stackoverflow.com/a/36509042

        // delegates
        /// <summary>
        /// Represents a method that is used to perform some action on a control that is enumerated
        /// when scanning a form's control tree (in the function 
        /// </summary>
        /// <param name="enumeratedControl">The control that was last enumerated from the form's control tree.</param>
        /// <param name="formControlStack">The stack containing controls enumerated from the form's control tree.</param>
        public delegate void ControlEnumerationDelegate(Control enumeratedControl, ref Stack<Control> formControlStack);

        // fields
        /// <summary>
        /// Dictionary of font styles extracted from the program forms (key) and
        /// developer-specified font styles (values).
        /// </summary>
        private static Dictionary<Font, Font> programStyles;
        /// <summary>
        /// List of reference to forms that make up the program (that the developer submitted
        /// when running the 'scanFormForFonts' function). Used when changing font styles.
        /// </summary>
        private static List<Form> programForms;

        /// <summary>
        /// A list of the program fonts in list form, in export-able form
        /// (this list is exposed to the developer by a read-only property).
        /// List is populated in getProgramFontStyles()
        /// </summary>
        private static List<Tuple<Font, Font>> programStylesExportList;

        // functions that let developer specify fonts to replace original fonts
        #region FONT STYLE SETTING FUNCTIONS

        // -apply new font to all styles (match size)
        // -apply new font to range of font sizes (all fonts)
        // -apply new font to specific font name (fonts of all sizes that contain the name)

        /// <summary>
        /// Specifies a font to be swapped with all original fonts in the forms, regardless of
        /// the name, size, or style of an original font. The original fonts will be replaced with
        /// a font of the original size and style but with the characters from the newFontFamily parameter.
        /// NOTE: At least 1 form must be scanned before this function can be run.
        /// </summary>
        /// <param name="newFontFamily">The family of the new font.</param>
        public static void specifyUniversalFont(FontFamily newFontFamily)
        {
            // ensure that programStyles dictionary is initialized
            if (programStyles == null)
            {
                // throw exception since can't proceed
                throw new Exception("No fonts available to replace! Ensure that all forms were scanned through scanFormForFonts() before calling this function.");
            }

            // specify replacement fonts for all fonts in programStyles
            for (int m = 0; m < programStyles.Count; m++)
            {
                // specify a replacement font that has the same size and style, but from
                // the newFontFamily.
                programStyles[programStyles.Keys.ElementAt(m)] =
                    new Font(newFontFamily,
                        programStyles.Keys.ElementAt(m).SizeInPoints,
                        programStyles.Keys.ElementAt(m).Style);
            }
        }

        /// <summary>
        /// Specifies a font to be swapped with original fonts whose Size property matches sizeToReplace. The replacement 
        /// fonts are generated from newFontFamily with the style specified in newFontStyle (if it is not set to null). 
        /// NOTE: At least 1 form must be scanned before this function can be run.
        /// </summary>
        /// <param name="newFontFamily">The family of the new font.</param>
        /// <param name="newFontStyle">The style of the replacement font. If you want to keep the original font style, set this to null.</param>
        /// <param name="sizeToReplace">The font size (of original fonts) that the new font is to replace.</param>
        public static void specifyFontForSize(FontFamily newFontFamily, FontStyle? newFontStyle, float sizeToReplace)
        {
            // ensure that programStyles dictionary is initialized
            if (programStyles == null)
            {
                // throw exception since can't proceed
                throw new Exception("No fonts available to replace! Ensure that all forms were scanned through scanFormForFonts() before calling this function.");
            }

            // specify replacement fonts for all fonts in programStyles
            for (int m = 0; m < programStyles.Count; m++)
            {
                // check if original font size matches sizeToReplace
                if (programStyles.Keys.ElementAt(m).Size == sizeToReplace)
                {
                    // check if new font style specified
                    if (newFontStyle != null)
                    {
                        // specify a replacement font from newFontFamily and with
                        // the style specified in newFontStyle
                        programStyles[programStyles.Keys.ElementAt(m)] =
                            new Font(newFontFamily,
                                programStyles.Keys.ElementAt(m).SizeInPoints,
                                newFontStyle.Value);
                    }
                    else
                    {
                        // specify a replacement font from newFontFamily, but with the original
                        // font size and style
                        programStyles[programStyles.Keys.ElementAt(m)] =
                            new Font(newFontFamily,
                                programStyles.Keys.ElementAt(m).SizeInPoints,
                                programStyles.Keys.ElementAt(m).Style);
                    }
                }
            }
        }

        /// <summary>
        /// Specifies a font to be swapped with original fonts whose Size property is between minSizeToReplace and 
        /// maxSizeToReplace, inclusive. The replacement fonts are generated from newFontFamily with the style specified 
        /// in newFontStyle (if it is not set to null). NOTE: At least 1 form must be scanned before this function can be run.
        /// </summary>
        /// <param name="newFontFamily">The family of the new font.</param>
        /// <param name="newFontStyle">The style of the replacement font. If you want to keep the original font style, set this to null.</param>
        /// <param name="minSizeToReplace">The inclusive minimum font size (of original fonts) that the new font is to replace.</param>
        /// <param name="maxSizeToReplace">The inclusive maximum font size (of original fonts) that the new font is to replace.</param>
        public static void specifyFontForSizeRange(FontFamily newFontFamily, FontStyle? newFontStyle,
            float minSizeToReplace, float maxSizeToReplace)
        {
            // ensure that programStyles dictionary is initialized
            if (programStyles == null)
            {
                // throw exception since can't proceed
                throw new Exception("No fonts available to replace! Ensure that all forms were scanned through scanFormForFonts() before calling this function.");
            }

            // specify replacement fonts for all fonts in programStyles
            for (int m = 0; m < programStyles.Count; m++)
            {
                // check if original font size matches sizeToReplace
                if (programStyles.Keys.ElementAt(m).Size >= minSizeToReplace &&
                    programStyles.Keys.ElementAt(m).Size <= maxSizeToReplace)
                {
                    // check if new font style specified
                    if (newFontStyle != null)
                    {
                        // specify a replacement font from newFontFamily and with
                        // the style specified in newFontStyle
                        programStyles[programStyles.Keys.ElementAt(m)] =
                            new Font(newFontFamily,
                                programStyles.Keys.ElementAt(m).SizeInPoints,
                                newFontStyle.Value);
                    }
                    else
                    {
                        // specify a replacement font from newFontFamily, but with the original
                        // font size and style
                        programStyles[programStyles.Keys.ElementAt(m)] =
                            new Font(newFontFamily,
                                programStyles.Keys.ElementAt(m).SizeInPoints,
                                programStyles.Keys.ElementAt(m).Style);
                    }
                }
            }
        }

        /// <summary>
        /// Specifies a font to be swapped with all original fonts whose name matches the parameter fontNameToReplace, regardless of
        /// the name, size, or style of an original font. The original fonts will be replaced with a font of the original size and 
        /// style (if newFontStyle is not set to null) but with the characters from the newFontFamily parameter.
        /// NOTE: At least 1 form must be scanned before this function can be run.
        /// </summary>
        /// <param name="newFontFamily">The family of the new font.</param>
        /// <param name="newFontStyle">The style of the replacement font. If you want to keep the original font style, set this to null.</param>
        /// <param name="fontNameToReplace">Original fonts with the name specified in this parameter will be replaced.</param>
        public static void specifyFontForFontFamily(FontFamily newFontFamily, FontStyle? newFontStyle, string fontNameToReplace)
        {
            // ensure that programStyles dictionary is initialized
            if (programStyles == null)
            {
                // throw exception since can't proceed
                throw new Exception("No fonts available to replace! Ensure that all forms were scanned through scanFormForFonts() before calling this function.");
            }

            // ensure that fontNameToReplace isn't null or blank
            if (fontNameToReplace == null || fontNameToReplace == "")
            {
                throw new Exception("No font name specified for replacement, cannot proceed.");
            }

            // specify replacement fonts for all fonts in programStyles
            for (int m = 0; m < programStyles.Count; m++)
            {
                // check if font name of original font matches
                if (programStyles.Keys.ElementAt(m).Name == fontNameToReplace)
                {
                    // check if new font style specified
                    if (newFontStyle != null)
                    {
                        // specify a replacement font from newFontFamily and with
                        // the style specified in newFontStyle
                        programStyles[programStyles.Keys.ElementAt(m)] =
                            new Font(newFontFamily,
                                programStyles.Keys.ElementAt(m).SizeInPoints,
                                newFontStyle.Value);
                    }
                    else
                    {
                        // specify a replacement font from newFontFamily, but with the original
                        // font size and style
                        programStyles[programStyles.Keys.ElementAt(m)] =
                            new Font(newFontFamily,
                                programStyles.Keys.ElementAt(m).SizeInPoints,
                                programStyles.Keys.ElementAt(m).Style);
                    }
                }
            }
        }

        #endregion

        // functions that are run whenever a control is enumerated when traversing a form's control tree
        #region CONTROL ENUMERATION DELEGATES

        /// <summary>
        /// Checks if the font of controlToMod has been added to programStyles as a key (one of the original fonts
        /// in the form). If not, the control's font is added to programStyles as a new entry with a null value.
        /// </summary>
        /// <param name="enumeratedControl">The control that was last enumerated from the form's control tree.</param>
        /// <param name="formControlStack">The stack containing controls enumerated from the form's control tree.</param>
        private static void scanControlForFont(Control enumeratedControl, ref Stack<Control> formControlStack)
        {
            // ensure that program styles is not null
            if (programStyles == null)
            {
                // initialize it, since an item will be added to it.
                programStyles = new Dictionary<Font, Font>();
            }

            if (!programStyles.ContainsKey(enumeratedControl.Font) &&
                enumeratedControl.Font != null)
            {
                // add the font to the dictionary with a null value and proceed to step 1.
                programStyles.Add(enumeratedControl.Font, null);
            }
        }

        /// <summary>
        /// Gets the font of enumeratedControl, finds the font to replace it with (in the programStyles dictionary), and
        /// replaces the control's font. If the replacement font is null, or the control hasn't been previously scanned (its
        /// font isn't in the programStyles dictionary as a key), no change occurs.
        /// </summary>
        /// <param name="enumeratedControl">The control that was last enumerated from the form's control tree.</param>
        /// <param name="formControlStack">The stack containing controls enumerated from the form's control tree.</param>
        private static void updateControlFont(Control enumeratedControl, ref Stack<Control> formControlStack)
        {
            // ensure that program styles is not null
            if (programStyles == null)
            {
                return;
            }

            // ensure that programStyles dictionary contains the enumeratedControl's font as a key
            // (otherwise there's no replacement font, or the control has had its font replaced already)
            if (programStyles.ContainsKey(enumeratedControl.Font))
            {
                // ensure the replacement font isn't null (otherwise there's nothing to change)
                if (programStyles[enumeratedControl.Font] != null)
                {
                    // replace the font in the control
                    enumeratedControl.Font = programStyles[enumeratedControl.Font];
                }
            }
        }

        #endregion

        /// <summary>
        /// Returns a list of program font styles, as a read-only list of tuples. The first item is an original
        /// font (from the forms scanned in the scanFormForFonts() function), while the second item is the font
        /// that will replace it when applyFontChanges() is called.
        /// </summary>
        /// <returns>Null, if no forms have been scanned in the scanFormForFonts() function. Otherwise it will return
        /// a read-only list of 2-item tuples as described in the description of this function.</returns>
        public static System.Collections.ObjectModel.ReadOnlyCollection<Tuple<Font,Font>>
            getProgramFontStyles()
        {
            // ensure that programStyles is initialized
            if (programStyles != null)
            {
                // check if programStylesExportList needs to be initialized
                if (programStylesExportList == null)
                {
                    // initialize the list
                    programStylesExportList = new List<Tuple<Font, Font>>();
                }

                // check if list is already populated
                // -only populate list if it is empty (will be if list was never populated in the first place,
                //  or developer scanned a new form in the scanFormForFonts() function, which means changes may have occurred).
                if (programStylesExportList.Count == 0)
                {
                    // populate the programStylesExportList from the programStyles dictionary
                    for (int m = 0; m < programStyles.Keys.Count; m++)
                    {
                        // add tuple to list, with key as first item and value as second item
                        programStylesExportList.Add(new Tuple<Font, Font>(
                            programStyles.Keys.ElementAt(m),
                            programStyles[programStyles.Keys.ElementAt(m)]));
                    }
                }
                // otherwise list was populated in a previous call to this function and no changes have occurred since then.
                // -return the list as readonly
                return programStylesExportList.AsReadOnly();
            }

            // otherwise, return null (since font list is not initialized)
            return null;
        }

        /// <summary>
        /// Checks the form (passed in as the parameter formToScan) and all of its controls for different font styles. If new
        /// ones are found, they are added to an internal dictionary of font styles.
        /// </summary>
        /// <param name="formToScan">The form to scan for fonts.</param>
        public static void scanFormForFonts(Form formToScan)
        {
            #region CHECK FOR ERRORS / ENSURE VARIABLES ARE INITIALIZED

            // ensure that formToScan isn't null
            if (formToScan == null)
            {
                // throw exception
                throw new Exception("Form passed in parameter 'formToScan' is null, cannot proceed.");
            }

            // ensure that programStyles is initialized
            if (programStyles == null) { programStyles = new Dictionary<Font, Font>(); }
            // ensure that programForms is initialized
            if (programForms == null) { programForms = new List<Form>(); }

            #endregion

            // check if form already scanned (IE is in the "programForms" list)
            if (!programForms.Contains(formToScan))
            {
                #region COMMENTED CODE

                //// declare local variables
                //// -used to store control tree
                //Stack<Control> formControlStack = new Stack<Control>();
                //// -used to store the control that was most recently popped off the formControlStack
                //Control lastPoppedControl = null;

                #region CHECK ALL FORM CONTROLS FOR FONTS (original, commented)

                //// enumerate control tree by populating stack with controls
                //// -first, add form to stack
                //formControlStack.Push(formToScan);

                ///*======PROCEDURE TO ENUMERATE CONTROLS======
                // * 1. Add form to stack, to start it.
                // * 2. While stack is not empty:
                // *      1. Pop item off stack, store in lastPoppedControl
                // *      2. Check if item has children; if it does, push them all onto stack.
                // *      3. Check if lastPoppedControl's font is a key of programStyles. If it is, proceed to step 1.
                // *         If not, add the font to the dictionary with a null value and proceed to step 1.
                // */

                //// continue until stack is empty
                //while (formControlStack.Count > 0)
                //{
                //    // 1. Pop item off stack, store in lastPoppedControl
                //    lastPoppedControl = formControlStack.Pop();

                //    // 2. Check if item has children; if it does, push them all onto stack.
                //    if (lastPoppedControl.HasChildren)
                //    {
                //        for (int m = 0; m < lastPoppedControl.Controls.Count; m++)
                //        {
                //            formControlStack.Push(lastPoppedControl.Controls[m]);
                //        }
                //    }

                //    /*      3. Check if lastPoppedControl's font is a key of programStyles. If it is, proceed to step 1.
                //    *          If not, add the font to the dictionary with a null value and proceed to step 1.
                //     */
                //    if (!programStyles.ContainsKey(lastPoppedControl.Font))
                //    {
                //        // add the font to the dictionary with a null value and proceed to step 1.
                //        programStyles.Add(lastPoppedControl.Font, null);
                //    }
                //    // otherwise, font was already added to dictionary. Proceed to step 1
                //}

                #endregion

                #endregion

                // enumerate form control tree, scan all controls to find all the fonts
                // that the form has (to enumerate all fonts/styles in the form)
                enumerateFormControlTree(formToScan, scanControlForFont);

                // add form to programForms list
                programForms.Add(formToScan);

                if (programStylesExportList != null)
                {
                    // if not null, clear the programStylesExportList (since a new form was added,
                    // which means new fonts might have been detected)
                    programStylesExportList.Clear();
                }
                // if it is null, then it will be initialized in getProgramFontStyles() when it gets called
            }
            // otherwise form was already scanned, no need to check again
        }

        /// <summary>
        /// Applies the new font styles to all the forms that were passed into the scanFormForFonts() function.
        /// Note: If no replacement font has been specified for a particular font, no changes will occur to controls that have that font.
        /// </summary>
        public static void applyFontChanges()
        {
            // check for errors (ensure that list of forms is not null)
            #region ERROR CHECKS

            // check if program forms list is null
            if (programForms == null)
            {
                // return false since form list hasn't been initialized
                throw new Exception("No forms were scanned for font changes; cannot run function.");
            }

            #endregion

            // iterate through all forms, applying changes to all controls
            for (int m = programForms.Count - 1; m >= 0; m--)
            {
                //  check if form is null (for example, original item disposed of)
                if (programForms[m] == null)
                {
                    // remove form from list (since it is null)
                    programForms.RemoveAt(m);
                }
                else
                {
                    // iterate through controls in form and update their font to match the fonts
                    // specified by developer
                    enumerateFormControlTree(programForms[m], updateControlFont);
                }
            }
        }

        /// <summary>
        /// Enumerates a form's control tree by traversing it with a stack. The parameter controlModifierDelegate represents
        /// a function that is run on every control that is enumerated.
        /// </summary>
        /// <param name="formToEnumerate">The form whose control tree will be enumerated.</param>
        /// <param name="controlModifierDelegate">Function that will be run whenever a control is enumerated from the formToEnumerate's control tree.</param>
        private static void enumerateFormControlTree(Form formToEnumerate, ControlEnumerationDelegate controlModifierDelegate)
        {
            // ensure that formToEnumerate and controlModifierDelegate are not null
            #region ERROR CHECKS

            // check if formToEnumerate is null
            if (formToEnumerate == null)
            {
                // throw exception, can't proceed
                throw new Exception("Parameter 'formToEnumerate' is null, can't proceed.");
            }

            // check if controlModifierDelegate is null
            if (controlModifierDelegate == null)
            {
                // throw exception, can't proceed
                throw new Exception("Parameter 'controlModifierDelegate' is null, can't proceed.");
            }

            #endregion

            // declare local variables
            // -used to store control tree for a form
            Stack<Control> formControlStack = new Stack<Control>();
            // -used to store the control that was most recently popped off the formControlStack
            Control lastPoppedControl = null;

            // add form to stack to start process
            formControlStack.Push(formToEnumerate);

            // continue until stack is empty
            while (formControlStack.Count > 0)
            {
                // 1. Pop item off stack, store in lastPoppedControl
                lastPoppedControl = formControlStack.Pop();

                // 2. Check if item has children; if it does, push them all onto stack (except null ones).
                if (lastPoppedControl.HasChildren)
                {
                    // push all child controls onto stack, ensuring they aren't null
                    for (int m = 0; m < lastPoppedControl.Controls.Count; m++)
                    {
                        // ensure child isn't null
                        if (lastPoppedControl.Controls[m] != null)
                        {
                            // add to form control stack
                            formControlStack.Push(lastPoppedControl.Controls[m]);
                        }
                    }
                }

                /* 3. Run the controlModifierDelegate, passing lastPoppedControl and
                 *    formControlStack into the function as parameters.
                 */
                controlModifierDelegate(lastPoppedControl, ref formControlStack);
            }
        }
    }
}
