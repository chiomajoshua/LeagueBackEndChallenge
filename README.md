# LeagueBackEndChallenge


## Project Structure

    .
    ├── src                                     # Application Source Files.
            ├──app
                    ├── api
    |                   └── ComputeMatrix       # ComputeMatrix Web API
                        └── ComputeMatrix.Core  # Core Logic
                        └── ComputeMatrix.Test  # Tests
    ├── .gitignore                              # Git ignore.
    ├── README.md                               # This file.
    

#### API Documentation
API documentation is [here](https://{deployedLocation}/swagger)

#### Technologies Used
- dotnet 6
- NUnit 
- Moq

#### Getting Started

##### Prerequisites
- dotnet 6 SDK needs to be installed on your machine. See [dotnet 6 Docs](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual studio 2022 needs to be installed

##### Setting up locally
- Clone with SSH => `git@github.com:chiomajoshua/LeagueBackEndChallenge.git`
- Clone with HTTPS => `https://github.com/chiomajoshua/LeagueBackEndChallenge.git`


##### Running the app on an attached device
- Open project with visual studio
- If Nugets do not restore automatically, right-click on the solution folder and select Restore Nuget Packages
- Build and Run the project.
- Run `dotnet run` in command prompt

    