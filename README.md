# FibonacciCalculator and TextProcessor
**FibonacciCalculator and TextProcessor** is a **learning project** built to explore **C#, .NET 8.0, and ASP.NET Core**. Before this, I had only basic knowledge of C# syntax, so this project was a way to **practice and solidify my understanding** of the language and its ecosystem.

It provides tools for **Fibonacci calculations** and **text processing**, structured into three main components:

- **LenaLearning (Class Library):** Contains the core logic, including Fibonacci sequence calculations and text manipulation methods.
- **RunApp (Console Application):** A console-based menu system that allows user interactions with the class library functionalities.
- **LenaLearningApi (ASP.NET Core Web API):** Exposes the class library functionalities as a RESTful web API for external integration, allowing to interact with the Fibonacci and text processing operations via HTTP requests.

## 🖥️ Development Environment
This project was developed using **Visual Studio 2022** as the IDE, along with **.NET 8.0** and **ASP.NET Core** for building the backend logic and API. 

## 📂 Main Project Structures
- [`LenaLearning/`]() -> Class Library (Core logic) 
    - [`Fibonacci.cs`]() -> Fibonacci calculations methods
    - [`MyException`]() -> Custom exception handling
    - [`WordProcessor.cs`]() -> Text processing methods
- [`LenaLearningApi/`]() -> API (Web Interface) 
    - [`Controllers/`]() 
        - [`FibonacciController.cs`]() -> Endpoints for Fibonacci operations
        - [`WordProcessorController.cs`]() -> Endpoints for text processing 
    - [`Models/`]()
        - [`FibonacciModel`]() -> Contains models for Fibonacci-related responses
        - [`WordProcessorModel`]() -> Contains models for text processing results
    - [`Program.cs`]() -> API configuration
- [`RuaApp`]() -> Console App (CLI Interface) 
    - [`Menus/`]() 
        - [`AppMainMenu.cs`]() -> Main interactive menu  
        - [`FibonacciMenu.cs`]() -> Fibonacci calculator menu
        - [`WordProcessorMenu.cs`]() -> Text processor menu
    - [`Program.cs`]() -> Console app entry point



## 🚀 Key features
#### Fibonacci Calculator
- Calculate the **n-th Fibonacci number**.
- Generate the **Fibonacci sequence up to a given number**.
- Generate the **Fibonacci sequence between two given numbers**.

#### Text Processor
- **Check the current text** in memory.
- **Set new text** for processing
- Count **total words** in the set text.
- Count **occurrences of a specific word**.
- Count **sentences** in the set text.
- Retrieve **characters and words by position** (1-starting index).
- Retrieve **the nth word** from the text.

##### **Note**: The **RunApp**(CLI) and **LenaLearningApi**(Web API) are separate appplications and must be run independently.

## 📌 What I Learned
This project was my **first real experience coding in C#**, beyond just knowing basic syntax. I built it as a **hands-on way to learn and improve in**:

- **C# programming concepts** (OOP, exception handling, regex, user input validation).
- **.NET 8.0** best practices and project structuring.
- Building a **Web API with ASP.NET Core** and controllers,  with a focus on **RESTful API design**.
- **Console applications** and structured menus.
- **Handling errors and user input safely** in both console and API environments.

This was a simple but valuable learning experience to improve my C# skills!
If anyone finds it useful, feel free to explore it. 😊
