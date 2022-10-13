# ACME Webhooks Samples

Copyright © 2022 Callflow Software Ltd.

A webhook (also called a web callback or HTTP push API) is a way for an app to provide other applications with real-time information. A webhook delivers data to other applications as it happens, meaning you get data immediately.

In cubu, webhooks notify external programs of various events and, in some cases, allow the external program to return information that will affect the standard cubu’s behavior.

This project is a standard dotNet Core Web API project, demonstrating the implementation of a "webhooks service".
The project is using the `WebhooksRouterMiddleware` from the `Cubu.Webhooks.Router` package for routing requests.

To learn more about cubu webhooks, see [Webhooks](https://qnomy.atlassian.net/wiki/spaces/CKB/pages/1840840730/Webhooks) in cubu Knowledge Base.

## Setup

To add the `Cubu.Webhooks` package to your project, type:

```sh
$ dotnet add package Cubu.Webhooks.Router --version 1.0.0-beta2
```

In the `Startup.cs`, the cubu Router middleware is registered using `app.UseWebhooksRouter`.
The file provide a few sample for different authentication options (basic, certificate, token, and none).

For more information, see `Cubu.Router' documentation.

## Dev tips

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
