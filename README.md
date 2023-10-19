# Authentication Tutorial

## Table of Contents
- [Introduction](#introduction)
- [Assumptions](#assumptions)

## Introduction

ASP.NET Core Identity provides us a login functionality which gives us a way to ensure 
that our data is secured. In order to protect the user's password, it uses an hashing algorithm to transform the password into a garbled string and is complemented by password salting. Password salting adds a randomized characters before it gets hashed.

## Assumptions
The user must clone a specific branch which is the DEV-003-CREATING-STUDENT-CONTROLLER.
``` sh 
Syntax:
git clone --single-branch --branch <branch_name> <github_clone_url>

Example:
git clone --single-branch --branch DEV-003-CREATING-STUDENT-CONTROLLER https://github.com/ettienekorayyi/authentication-tutorial.git
```