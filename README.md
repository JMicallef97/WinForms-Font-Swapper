# WinForms Font Swapper
 
Tired of manually changing fonts all the time when trying to get the look of your windows form project right?
Maybe at certain sizes the font you picked is unreadable, or maybe you can't or don't want to use default
fonts. I've been there myself, that's why I wrote this library.

WinForms Font Swapper is a C# library that allows you to quickly change fonts across multiple windows forms with only a
few lines of code. The DLL for the library is located in the "Releases" section of this page.

There's a windows form project in the folder called "WFS Test Program - Source Code and Program" that demonstrates the library features.
If you want the source code for the program, it's all located in "WFS Test Program - Source Code And Program\WFS_Test_Form.cs".
If you just want the executable form of the program, it's located in "WFS Test Program - Source Code And Program\bin\Debug\WFS Test Program.exe".

# How to Use

1. Scan all the forms you want to apply font changes to by calling WinFormsFontSwapper.scanFormForFonts()
```
WinFormsFontSwapper.scanFormForFonts([your form name here]);
```

2. Specify the fonts you want to change. You can specify replacement fonts by the following methods: Replace all fonts,
replace fonts by size, replace fonts by size range, replace fonts by name, or replace fonts directly. Examples are below.

**REPLACE ALL (Universal Font)**
```
// Specify a universal font (replace all fonts with this font).

// Original fonts will be replaced with a font that is the original 
// size and style, but from the font family you specify in the parameter.

WinFormsFontSwapper.specifyUniversalFont(
	[family of the font you want to replace]);

```

**REPLACE BY SIZE**
```
// -Only replace original fonts that match a particular size
// (specified in the 3rd parameter). 

// Replacement fonts will be the same size as the original font.

// -You can override the style of the original font by passing
// a FontStyle object in the second parameter, or set it to null
// to have the replacement font keep the style of the original fonts
// that it replaces.

WinFormsFontSwapper.specifyFontForSize(
	[family of the font you want to replace],
	[Null OR new font style],
	[Original font size to replace]);

```

**REPLACE BY SIZE RANGE**
```
// -Only replace original fonts that fall within a size range,
// with the minimum size specified in the 3rd parameter and maximum
// size specified in the 4th parameter. The range is inclusive.

// Replacement fonts will be the same size as the original font.

// -You can override the style of the original font by passing
// a FontStyle object in the second parameter, or set it to null
// to have the replacement font keep the style of the original fonts
// that it replaces.

WinFormsFontSwapper.specifyFontForSizeRange(
	[family of the font you want to replace],
	[Null OR new font style],
	[Minimum original font size to replace],
	[Maximum original font size to replace]);

```

**REPLACE BY FONT FAMILY NAME**
```
// -Only replace original fonts that match the font name, specified
// in the 3rd parameter. 

// Replacement fonts will be the same size as the original font.

// -You can override the style of the original font by passing
// a FontStyle object in the second parameter, or set it to null
// to have the replacement font keep the style of the original fonts
// that it replaces.

WinFormsFontSwapper.specifyFontForFontFamily(
	[family of the font you want to replace],
	[Null OR new font style],
	[Name of original font to replace]);

```

**REPLACE BY FONT**
```
// -Replace fonts that match the name, size and style
//  specified in the 2nd, 3rd, and 4th parameters with the
//  Font object specified in the 1st parameter.

WinFormsFontSwapper.specifyFontForFont(
	[Replacement font, as font object],
	[name of the font you want to replace],
	[size of the font you want to replace],
	[style of the font you want to replace]);

```

3. Finally, called the function WinFormsFontSwapper.applyFontChanges() to apply the replacement fonts to all forms
that were scanned in step 1.

```
WinFormsFontSwapper.applyFontChanges();
```

# Undoing Font Changes

The function below will reset all font changes, by restoring each control's original font.
```
WinFormsFontSwapper.resetFontChanges();
```

# Clearing Replacement Fonts

The function below will clear all replacement fonts from the WinForms Font Swapper library, but it will not change the fonts of any controls.
```
WinFormsFontSwapper.clearReplacementFonts();
```

# Resetting Windows Font Swapper

The function below will reset the Windows Font Swapper library to its starting state (that is, as if it had just been initialized).
```
WinFormsFontSwapper.resetWFSState();
```

# Getting a List of Original & Replacement Fonts

There are 2 ways to get the original and replacement program fonts.

The first way is a read-only list of 2-item tuples. The first item is the original font, while the second item is the replacement font. The following function returns the list:
```
WinFormsFontSwapper.getProgramFontStyles();
```

The other way is to get a string representation of the original & replacement font list, returned from the following function:
```
WinFormsFontSwapper.getProgramFontStyleList();
```

The format is a numbered list of original fonts (next to the numbers) and replacement fonts (below the original fonts) (or "[None]" if no replacement font is specified). Each entry is separated by a space. An example from the test program is listed below:
```
1. [Font: Name=Microsoft Sans Serif, Size=8.25, Units=3, GdiCharSet=0, GdiVerticalFont=False]
[None]

2. [Font: Name=Segoe UI, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False]
[None]

3. [Font: Name=Microsoft Sans Serif, Size=20.25, Units=3, GdiCharSet=0, GdiVerticalFont=False]
[None]

4. [Font: Name=Calibri, Size=12, Units=3, GdiCharSet=0, GdiVerticalFont=False]
[None]

5. [Font: Name=Arial Narrow, Size=21.75, Units=3, GdiCharSet=0, GdiVerticalFont=False]
[None]

6. [Font: Name=Microsoft Sans Serif, Size=9.75, Units=3, GdiCharSet=0, GdiVerticalFont=False]
[None]

7. [Font: Name=Microsoft Sans Serif, Size=12, Units=3, GdiCharSet=0, GdiVerticalFont=False]
[None]
```

# Notes

1. If a replacement font is not specified for an original font, no changes will be made to the font and no errors will occur.

2. Fonts WILL NOT be replaced unless you add
```
Application.SetCompatibleTextRenderingDefault(true);
```
to the Main() function in Program.cs.

# Version & Dependency Information

I created this with Visual Studio C# 2010, using .Net Framework 4, on November 22 2023. This library does not use any external dependencies.

# Licensing

Both the library and test program are licensed under the MIT license. The replacement font used in the test program is called "ShareTechMono_Regular", and a copy of its license (the SIL open font license) is located at "WFS Test Program - Source Code And Program\Licenses\". If you use this library in a project I'd love to hear about it!

Please make sure that you have permission (e.g., a license or written permission) from the font creator before you use their fonts in your program.