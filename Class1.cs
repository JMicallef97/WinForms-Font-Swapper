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

        public static List<Tuple<Font, Font>> getProgramFontStyles()
        {
            // ensure that programStyles dictionary is populated
            // declare local variables
            MessageBox.Show("Todo; implement");
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
                #region CHECK ALL FORM CONTROLS FOR FONTS

                ggg

                #endregion

                // add form to programForms list
                programForms.Add(formToScan);
            }
            // otherwise form was already scanned, no need to check again
        }

        /// <summary>
        /// Applies specified font styles
        /// </summary>
        public static void applyFontChanges()
        {
            MessageBox.Show("Todo; implement 'applyFontChanges'");
        }
    }
}
