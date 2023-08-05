#NOTE
##########################################################################################################
#This script will install nextcloud
#it will install mariadb-server apache2 and php, there for this script is better on a clean installation
#You could modify this script to whatever you like too
#I just made this to make it easier for me to install nextcloud next time i need too set it up.
##########################################################################################################

sudo apt update && sudo apt upgrade
sudo apt install apache2 mariadb-server libapache2-mod-php php-gd php-mysql \
php-curl php-mbstring php-intl php-gmp php-bcmath php-xml php-imagick php-zip

sudo mysql

echo "Set a sub domain to use"
read sub_domain
echo "Set password for user: nextcloud on mariadb-server"
read my_password


CREATE USER 'nextcloud'@'localhost' IDENTIFIED BY $my_password;
CREATE DATABASE IF NOT EXISTS nextcloud CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
GRANT ALL PRIVILEGES ON nextcloud.* TO 'nextcloud'@'localhost';
FLUSH PRIVILEGES;

quit;

wget https://download.nextcloud.com/server/releases/latest.zip
unzip latest.zip

sudo cp -r nextcloud /var/www
sudo chown -R www-data:www-data /var/www/nextcloud

wget https://raw.githubusercontent.com/neisep/Labs/master/Labs/InstallScript/nextcloud.conf

sed -i ''s/ServerName .*/ServerName ${sub_domain}/'' nextcloud.conf
sudo cp -r nextcloud.conf /etc/apache2/sites-available/nextcloud.conf

a2ensite nextcloud.conf

#required modules
a2enmod rewrite

#recommended modules
a2enmod headers
a2enmod env
a2enmod dir
a2enmod mime

sudo service apache2 restart