#!/bin/bash

#NOTE
##########################################################################################################
#This script will install collaboraonline on Ubuntu or any deb based distributions
#
#You could modify this script to whatever you like too
#I just made this to make it easier for me to install nextcloud next time i need too set it up.
##########################################################################################################

#Install Collabora Online

cd /usr/share/keyrings
sudo wget https://collaboraoffice.com/downloads/gpg/collaboraonline-release-keyring.gpg

sudo wget https://raw.githubusercontent.com/neisep/Labs/master/Labs/InstallScript/cfg/collaboraonline.conf

sudo cp -r collaboraonline.conf /etc/apt/sources.list.d/collaboraonline.sources

sudo apt update && sudo apt install coolwsd code-brand

echo "You need to manually configure file: /etc/coolwsd/coolwsd.xml for Collabora"
echo "The default configuration is looking for an SSL certificate and key, which are not present, so probably it’s the best to disable SSL, and optionally enable SSL termination, then set up the reverse proxy"