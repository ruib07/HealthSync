To run this project, you have to complete the following steps:
    
- Create the database following these steps:
  - Delete Migrations folder in HealthSync.Infrastructure
  - On the terminal, "Add-Migration migration-name"
  - On the terminal, "Update-Database"
  
- You need to be with HealthSync.API as the StartUp Project and the terminal in the HealthSync.Infrastructure project
- Add a appsettings.json on your HealthSync.API with the following structure:
```json
{
  "ConnectionStrings": {
    "HealthSyncDB": "your connection string"
  },
  "Jwt": {
    "Issuer": "your issuer",
    "Audience": "your audience",
    "Key": "your key"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
- Then if you´re using VS2022, you can create a profile that start the HealthSync.API and the HealthSync.WinForms at the same time in the "Configure Startup Projects"

With this steps, you can have the project on your computer without any problem. Have a great day 😄

Patients: <br />
<img width="500" src="https://github.com/user-attachments/assets/9315eb7a-3e2e-475d-9f75-632a89156d4b" /> <img width="400" src="https://github.com/user-attachments/assets/d4ef7645-bf14-496b-8300-0ba52f1adff1" />

Create Patient: <br />
<img width="500" src="https://github.com/user-attachments/assets/7ebe2117-789d-4cbb-af62-f8756e750eba" />

Doctors: <br />
<img width="550" src="https://github.com/user-attachments/assets/5515970e-cbeb-4685-907c-92915d159ad9" /> <img width="350" src="https://github.com/user-attachments/assets/a0791ee6-79e7-4ce1-8ca3-288e2afa8058" />

Create Doctor: <br />
<img width="500" src="https://github.com/user-attachments/assets/5f162cdd-22ca-4079-a4f1-adca5be3fbdb" />

Appointments: <br />
<img width="500" src="https://github.com/user-attachments/assets/88400929-1bd0-48e0-9487-ce2b5facfc69" /> <img width="400" src="https://github.com/user-attachments/assets/0c089468-438d-458a-a46d-11fb1b256d0d" />

Create Appointment: <br />
<img width="500" src="https://github.com/user-attachments/assets/88c04c2a-f57b-4c87-9ea0-e2a328e17c9a" />

Appointments By Doctor: <br />
<img width="350" src="https://github.com/user-attachments/assets/b123333a-6c8b-4af7-b386-f06f864f4314" /> <img width="550" src="https://github.com/user-attachments/assets/c922c68d-5dc0-46d4-8c90-7d851e968a6e" />

Appointments By Patient: <br />
<img width="350" src="https://github.com/user-attachments/assets/9203f39d-c89e-4f02-848c-53e5cde9ae29" /> <img width="550" src="https://github.com/user-attachments/assets/e0b205ce-78e7-4feb-9a70-9d9b098cf5bd" />

Medical Records: <br />
<img width="500" src="https://github.com/user-attachments/assets/283aacc9-f5ef-4f19-a597-e2e26640881f" /> <img width="400" src="https://github.com/user-attachments/assets/0f058001-5b03-495b-8889-d1a38071c961" />

Create Medical Record: <br />
<img width="500" src="https://github.com/user-attachments/assets/23595af9-5331-4029-9e1a-b87842c53030" />

Medical Records By Patient: <br />
<img width="350" src="https://github.com/user-attachments/assets/18cba6b6-3830-40c2-9f9b-778928e3dd08" /> <img width="550" src="https://github.com/user-attachments/assets/3964dcb7-5463-45f0-8732-582c0c33a5d1" />




















