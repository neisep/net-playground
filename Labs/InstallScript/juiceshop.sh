#!/bin/bash

#NOTE
##########################################################################################################
#This script will install JuiceShop on Ubuntu or any deb based distributions
#You could modify this script to whatever you like too
#I just made this to make it easier for me to install juiceShop next time i need too set it up.
#Notice 1GB in memory is not enought just saying, if you get errors...
##########################################################################################################

#First we need to install nodejs but first we need to add nodesource to be able to get nodejs
sudo apt-get update
sudo apt-get install -y ca-certificates curl gnupg
sudo mkdir -p /etc/apt/keyrings
curl -fsSL https://deb.nodesource.com/gpgkey/nodesource-repo.gpg.key | sudo gpg --dearmor -o /etc/apt/keyrings/nodesource.gpg

NODE_MAJOR=20
echo "deb [signed-by=/etc/apt/keyrings/nodesource.gpg] https://deb.nodesource.com/node_$NODE_MAJOR.x nodistro main" | sudo tee /etc/apt/sources.list.d/nodesource.list

sudo apt-get update
sudo apt-get install nodejs -y

#Hopefully everything worked out fine, we should now get the source from juiceshop github
git clone https://github.com/juice-shop/juice-shop.git --depth 1

#travel to directory
cd juice-shop

#lets install/compile or whatever you do with frontend mumba jumba
npm install

echo "If everything worked out fine you should only need to run npm start in the source directory, hopefully your already in it else its in juice-shop in your home directory"

#npm start
