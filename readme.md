# ACME Webhooks Samples

This project is a sample project, demonstrating cubu Webhooks implementation.
It provide sample implementations of different webhooks.

cubu webhooks are essentially
This project is a standard dotNet Core Web API project, using the `WebhooksRouterMiddleware` from the `Cubu.Webhooks` package for routing requests.

To get the latest `Cubu.Webhooks` package, type:

```sh
$ dotnet add package Cubu.Webhooks
```

## Setup

In the `Startup.cs`, the cubu Router middleware is registered using `app.UseWebhooksRouter`.
The file provide a few sample for different authentication options (basic, certificate, token, and none).

For more information, see `Cubu.Router' documentation.

# Dev tips

To test the webhooks service locally, use [ngrok](https://ngrok.com/) to tunnel webhook request from the internet to your local machine.
(You will need to set up an ngrok account).

Follow the instruction to install ngrok on your dev machine.

### Connect to your account using:

```sh
$ ngrok authtoken <auth-token>
```

(You can get the authtoken from the ngrok dashboard).

### Start ngrok:

Important! use the `host-header` option when running ngrok.

```sh
$ ngrok http [port] -host-header="localhost:[port]"
```

For example, if your webhooks service is running on `localhost:6000`, run:

```sh
$ ./ngrok http 6000 -host-header="localhost:6000"
```

You will get a forwarding URL.
On cubu Global Settings tools/Webhooks page, set the webhook app base url to: **"\<ngrok-forwarding-url>/api/cubu"**

For example: `https://edcf1abfe6e8.ngrok.io/api/cubu`
(You can either use the http or https version)

### Allowing http

Comment out `app.UseHttpsRedirection()` in `Startup.cs`
