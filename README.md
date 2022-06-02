# How to run it
## Run the client app
1. switch to "Front" branch
1. download the zip file (Code -> Download Zip)
2. unzip
3. open the directory in the terminal
4. type the command `npm install`
5. type the command `npm start`


### existing users on the servers
note: pay attention to the case. (the database is case sensitive).
1. username:a password: aaaa
2. username:b password: aasaa
3. username:c password: aaasa
4. username:d password: aaaaa
5. username:e password: aaadaa
6. username:f password: aa3aa
7. username:g password: aaa2a
 <br />
the users above exist, but they have no chats or contacts, you can do whatever you want with them or create a new user.



# Run the api server 
1. switch to "master" branch
1. download the zip file (Code -> Download Zip)
2. unzip
3. open the ApiServer-master/ChatServer/ChatApi directory in the terminal
4. type the command `dotnet run`

# run the Reviews page
1. switch to "master" branch
1. download the zip file (Code -> Download Zip)
2. unzip
3. open the ApiServer-master/ChatServer/ChatServer directory in the terminal
4. type the command `dotnet run`
5. open https://localhost:7012 in a web browser

# Note
make sure ports 7012 and 7033 are available.
