# AdminUI Webhooks Sample

This repository contains a sample implementation of the Password Reset webhook for AdminUI. It demonstrates how to implement and integrate a secure webhook endpoint that can receive and process password reset requests from AdminUI.

## Overview

The AdminUI Webhooks sample provides a reference implementation for handling password reset requests securely using modern .NET 8 practices, including proper authentication, authorization, and error handling.

## Sample Projects

### WebHooksClient
- .NET 8 Web API implementing the Password Reset webhook endpoint
- Demonstrates secure webhook handling with JWT authentication
- Includes proper error handling and logging

## Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022, VS Code, or JetBrains Rider
- AdminUI instance configured for webhook integration
- Valid JWT token for authentication

## Quick Start

1. Clone this repository
2. Configure the authentication settings in appsettings.json:
   ```json
   {
     "Authentication": {
       "Authority": "http://localhost:5003",
       "RequireHttpsMetadata": false
     }
   }
   ```
3. Run the WebHooksClient project:
   ```bash
   cd WebHooksClient
   dotnet run
   ```
4. Configure AdminUI to use the webhook endpoint:
   - Endpoint: `https://localhost:5001/api/passwordreset`
   - Required scope: `admin_ui_webhooks`

## Documentation

For detailed information about implementing webhooks with AdminUI, see:
- [Extending AdminUI with Password Reset Webhooks](https://www.identityserver.com/articles/extending-adminui-with-newuser-and-passwordreset-webhooks/)

## Obtaining a License

To use AdminUI and its webhook functionality:
- Visit [identityserver.com](https://www.identityserver.com)
- Contact sales@identityserver.com for licensing information

## Support

For support questions:
- Check the [AdminUI documentation](https://www.identityserver.com/documentation/)
- Contact support@identityserver.com

## License

This sample code is licensed under the Apache License 2.0. See the [LICENSE](LICENSE) file for details.

AdminUI requires a commercial license from Rock Solid Knowledge.
