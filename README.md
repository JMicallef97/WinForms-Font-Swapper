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
```
// Specify a universal font (replace all fonts with this font).
// 	Original fonts will be replaced with a font that is the original 
// 	size and style, but from the font family you specify in the parameter.
WinFormsFontSwapper.specifyUniversalFont([family of the font you want to replace]);

```

I've added a sample project (called WFS Test Program) which contains a working example.