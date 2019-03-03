# Stealth Kid RAT (Concept)

<p align="left">
    <a href="https://github.com/SyafiqHadzir/Stealth-Kid-RAT/blob/Concept/LICENSE">
        <img src="https://img.shields.io/badge/License-MIT%20%2F%20Apache--2.0-blue.svg?style=plastic?maxAge=7200" alt="License - MIT">
    </a>
    <a href="https://github.com/SyafiqHadzir/Stealth-Kid-RAT/tree/Concept/dev/file-transfer/TCP/bin">
        <img src="https://img.shields.io/badge/Build-Passed-brightgreen.svg?style=plastic?maxAge=7200" alt="Build - Passed">
    </a>
    <img src="https://img.shields.io/badge/Development-Dormant-red.svg?style=plastic?maxAge=7200" alt="Development - Dormant">
</p>


**Codename: Alpha (Concept)**
 
Stealth Kid RAT is an opensource remote administration tool written in C.


**Currently developed features:**

* Secure connection between Client & Server


**Currently under development:**

* Webcam grabber function
* Secure TCP-UDP file transfer connection between Client & Server
* TCP network stream (IPv4 & IPv6 support)


**Installation**

SK-RAT needs The GNU Compiler Collection (GCC) compiler to run.

Install the client and server by compiling the source codes.

Server (server.c)

```sh
$ gcc server.c -o server -lnsl
$ ./server
```

Client (client.c)

```sh
$ gcc client.c -o client -lnsl
$ ./client
```

Disclaimer: Stealth Kid RAT source code is written intentionally for **EDUCATIONAL PURPOSES ONLY**. Don't use them for illegal activities.

Copyright (c) 2017 Syafiq Hadzir (Alexandrov)
