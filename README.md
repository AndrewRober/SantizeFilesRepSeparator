# EDI ISA11 Separator Sanitization Script

## Overview
This script is designed to replace the ISA11 separator in EDI (Electronic Data Interchange) files. The ISA11 separator, which is part of the **Interchange Control Header** segment, must conform to ASCII character standards. However, some implementations use non-ASCII characters in this position, which is illegal from an EDI standpoint. This script addresses this issue by identifying the separator and replacing it with a valid character (`^`).

## Script Functionality
This script:
1. Processes either a single file or all files in a directory.
2. Identifies the 83rd character (ISA11 separator, 0-based index 82).
3. Replaces all occurrences of the identified character with `^` throughout the file.
4. Writes the sanitized files to a separate `Sanitized Files` directory within the provided path, preserving the original files.

## Usage
1. **Run the Program**: Execute the script in a terminal or command prompt.
2. **Provide a Path**: Input the path to the directory or file containing EDI files when prompted.
3. **Sanitized Output**: The processed files will be saved in a new `Sanitized Files` directory at the specified location.

### Output
- Original files remain untouched.
- Sanitized files are saved in: \Sanitized Files


## Code Features
- **Non-destructive Processing**: Original files are not modified.
- **Automatic Directory Creation**: The `Sanitized Files` directory is created dynamically.
- **Error Handling**: Skips files with less than 83 characters and logs errors during processing.

## Why This Script?
The EDI ISA11 separator plays a critical role in ensuring data integrity and compliance. Non-ASCII characters in this position can cause interoperability issues. This script provides a simple and effective way to enforce compliance.

## License
This project is open source. Feel free to modify and distribute it according to your needs.
