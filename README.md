# WinForms Font Swapper
 

Tired of manually changing fonts all the time when trying to get the look of your windows form project right?
Maybe at certain sizes the font you picked is unreadable, or maybe you can't or don't want to use default
fonts. I've been there myself, that's why I wrote this library.

WinForms Font Swapper is a C# libray that allows you to quickly change fonts across multiple windows forms with only a
few lines of code. 

# How to Use

1. Scan all the forms you want to apply font changes to by calling WinFormsFontSwapper.scanFormForFonts()
```
WinFormsFontSwapper.scanFormForFonts([your form name here]);
```

2. Specify the fonts you want to change, using the following methods:

REPLACE ALL (Universal Font)
```
// Specify a universal font (replace all fonts with this font).

// Original fonts will be replaced with a font that is the original 
// size and style, but from the font family you specify in the parameter.

WinFormsFontSwapper.specifyUniversalFont(
	[family of the font you want to replace]);

```

REPLACE BY SIZE
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

REPLACE BY SIZE RANGE
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

REPLACE BY FONT FAMILY NAME
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

3. Finally, called the function WinFormsFontSwapper.applyFontChanges() to apply the replacement fonts to all forms
that were scanned in step 1.

```
WinFormsFontSwapper.applyFontChanges();
```

There's a sample windows form project in the folder called "WFS Test Program" that demonstrates an example as well.

# Notes

-If a replacement font is not specified for an original font, no changes will be made to the font and no errors will occur.
-Fonts WILL NOT be replaced unless you add
```
Application.SetCompatibleTextRenderingDefault(true);
```
to the Main() function in Program.cs.