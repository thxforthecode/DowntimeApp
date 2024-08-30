
# **Downtime Reporting App**

_This is a downtime reporting application originally built as part of my learning journey following a tutorial series by Tim Corey. I have since adapted and expanded the project to create a downtime reporting system for machine maintenance._


![createpage](https://github.com/user-attachments/assets/bfc6d50b-3c11-457a-b216-9e462a32c66b)
![indexpage](https://github.com/user-attachments/assets/99a81786-66a0-47eb-a099-a9d16c8c4153)


## Key Features

Downtime Reporting: Log downtime events, categorize them, and provide relevant details.
Machine-Specific Parts Tracking: Create a machine-specific list of parts that can be individually selected when authoring downtime reports. This helps in tracking replacements and maintenance history.
User Authentication: Secure login and user management using Azure AD B2C.
Blazor Frontend with MongoDB Backend: A modern tech stack using Blazor for a dynamic single-page application experience and MongoDB for flexible, NoSQL data storage.


## Getting Started

To get a local copy of this app running, follow these steps:

### Prerequisites:

 - __.NET SDK installed__
 - __MongoDB installed locally or access to a MongoDB cloud instance__
 - __An Azure AD B2C tenant set up__
 - __A development environment set up for Blazor (e.g., Visual Studio, Visual Studio Code)__

### Installation
Clone the Repository:

Update the appsettings.json file in the Server project with your Azure AD B2C details (e.g., tenant, client ID, etc.).

### Set Up MongoDB:

Update the connection string in appsettings.json with your MongoDB details.

### Run the Application!

## How This Project Differs from the Original

This project differs from Tim Corey's original tutorial in its purpose and added functionality:

### Purpose:
While the original tutorial was for a suggestion site, this project focuses on reporting and managing machine downtime events.

### Added Functionality:
Introduced a machine-specific parts list feature, allowing users to select individual parts when authoring downtime reports. This helps keep detailed records of parts replaced during downtime events.


## Future Plans:
Adding a feature to export downtime reports in various formats (e.g., CSV, PDF).

## Acknowledgements
Tim Corey: This project was originally coded side by side with Tim Corey's "Suggestion Site App" tutorial series. The code structure, especially in the initial stages, closely follows his approach. Thank you, Tim, for the educational content!

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.


