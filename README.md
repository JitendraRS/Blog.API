# Blog.API

Blog.API is a .net 6 web api for managing blog posts.

##Setup instructions

Clone API reposotory using command : git clone https://github.com/JitendraRS/Blog.API.git

##How to run the application

Run application using Visual Studio.

##A brief explanation of design decisions and application structure

Application Architecture overview: This application is following clean arhitecture and contains following layers.

1. Core Layer: Core layer should contain all data models, interfaces, enums, and constants. This layer should not reference any other layer nor any other components.

2. Application Layer: All business logic should be in the application layer. It should only reference core and have very minimal to no reference to external components.

3. Web API Layer:  ties all the layers together. It should contain the web controllers and infrastructure components. Logic in controllers should be kept to a minimum. In most cases, it should only invoke application layer component methods.

Infrastructure components include components that the application layer needs to integrate with external services or libraries such as database, APIs, logging, and third party components. This layer references both core and application layers. As much as possible, nuget packages and other external libraries should only be added to this layer.
