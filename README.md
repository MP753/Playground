# CodeReview Solution

Showcase solution for experimenting with modern .NET technologies, clean architecture principles, and idiomatic design patterns.
The purpose of this solution is to demonstrate hands-on knowledge of tooling, structure, and programming techniques used in professional-grade applications.

## 🔧 Setup & Tooling

- **Central Package Management** for consistent dependency versions across projects
- **Standardized Build Settings** shared via `.slnx`
- **Coding Style Enforcement** using `.editorconfig` and analyzers
- **Continuous Integration** via GitHub Actions
- **HTTP File Testing**: declarative `.http` files for endpoint testing inside IDE

## 🧩 Solution Structure

### Users Module

- **Layered Approach**: Composed of two separate projects
  - **BFF Layer** uses **Vertical Slice Architecture** 
  - **Microservice Layer** blends **Vertical Slice Architecture** and **Clean Architecture**
- **Technologies & Patterns Used**:
  - .NET **Minimal APIs** with **Carter** library
  - Custom implementation of **CQRS** 
  - **Result Pattern** for safe and expressive outcome handling
  - **Scrutor** library for automatic DI registration
  - **Refit library** for http clients
  - Validation: **FluentValidation** in bff
	


## 🔗 Connect with Me

Feel free to reach out or explore more of my work:

- [LinkedIn Profile](https://www.linkedin.com/in/milena-popovic-bg/)

---

