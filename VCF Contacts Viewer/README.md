# VCF Contacts Viewer (.NET 8 WinForms)

A simple **VCF (vCard) reader application** built with **C# and .NET 8 WinForms**. This tool allows users to open `.vcf` files, view file details, and display all contacts in a clean, read-only format.

---

## Overview

This project is a simple **VCF (vCard) reader application** built with **C# and .NET 8 WinForms**. It allows users to easily open `.vcf` files, view file details such as name, and size, and display all contacts in a clean, read-only format. 

The application is designed with a **modular architecture**, using a **ViewModel** for contacts and a **helper class** for parsing, making it easy to extend with additional fields or features in the future. 

It supports multiple contacts, displays company information, and sorts contacts alphabetically by first name for better readability.

---

## Features

- Open and read `.vcf` files easily  
- Display file details (name, size)  
- View all contacts in a **read-only format**  
- Supports multiple contacts  
- Displays contact **company information**  
- Sorts contacts **alphabetically by first name**  
- Modular architecture with **ViewModel** and **Helper classes** for easy extension  

---

## Project Structure



VCF Contacts Viewer <br/>
│<br/>
├── GlobalUsings.cs<br/>
├── Program.cs<br/>
│<br/>
├── Helpers<br/>
│   └── VcfParserHelper.cs<br/>
│<br/>
├── Models<br/>
│   └── ViewModels<br/>
│       └── ContactViewModel.cs<br/>
│<br/>
└── Views<br/>
    └── MainForm.cs<br/>



---

## Usage

1. Clone the repository:

```bash
git clone https://github.com/UmerFarooqOfficial/VCFContactsViewer.git
````

2. Open the solution in Visual Studio 2022 or later.

3. Build and run the project.

4. Click Open VCF File to select a .vcf file.

5. View file details and click View Contacts to display contacts.
<br/>

## License

This project is licensed under the [MIT License](LICENSE).  <br/>
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

---

## Developed By

**Umer Farooq** — [Portfolio](https://umerfarooqofficial.com)
