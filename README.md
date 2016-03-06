# barcoder
```
var input = "abc123";
var bc = new Barcode128(input);
var svg = bc.generateSvg();
Console.WriteLine(svg);
```

command line example:

```
barcoder-cli abc123 > barcode.svg
```

To use special chars, see this file: https://github.com/Arakis/barcoder/blob/master/src/barcoder/lib.cs
and use them in braces like `{FNC3}`.

To generate Honeywell barcode scanner programming barcodes, use this input format:

```
barcoder-cli ~<barcode>{FNC3} > barcode.svg
```
for example:
```
barcoder-cli ~AOSCGD1.{FNC3} > barcode.svg
```
