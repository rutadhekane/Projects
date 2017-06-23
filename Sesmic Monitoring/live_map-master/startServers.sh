#!/usr/bin/env bash
nohup rethinkdb --bind all --http-port 9090 &
nohup node app.js &
