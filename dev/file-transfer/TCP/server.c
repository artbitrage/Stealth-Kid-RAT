
/************************************
|               Server              |
*************************************

Codename: Alhpa (Concept)
Function: File Transfer (TCP)

Copyright (c) 2017 Syafiq Hadzir (Alexandrov)
*************************************/

#include <stdio.h>
#include <stdlib.h>

// Time function, sockets, htons... file stat
#include <sys/time.h>
#include <time.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/uio.h>
#include <sys/stat.h>

// File function and bzero
#include <fcntl.h>
#include <unistd.h>
#include <strings.h>

// Size of buffer used for sending file
#define BUFFERT 512

// Size of pending client connection
#define BACKLOG 1


// Function declaration
int duration (struct timeval *start,struct timeval *stop, struct timeval *delta);
int create_server_socket (int port);

struct sockaddr_in sock_serv,sock_clt;


int main (int argc, char *argv[]) {

    int sfd, fd;
    unsigned int length = sizeof(struct sockaddr_in);
    long int n, m,count = 0;
    unsigned int nsid;

    ushort clt_port;

    char buffer[BUFFERT], filename[256];
    char dst[INET_ADDRSTRLEN];

    // Date variable
	time_t intps;
	struct tm* tmi;

    if(argc!=2) {
        perror("Usage: ./a.out <num_port> <file2send>\n");
        exit(3);
    }

    sfd = create_server_socket(atoi(argv[1]));

    bzero(buffer,BUFFERT);
    listen(sfd, BACKLOG);

    // Function that wait for client to connect
    nsid = accept(sfd, (struct sockaddr*)&sock_clt, &length);
    if (nsid == -1){
        perror("Fail to receive file.\n");
        return EXIT_FAILURE;
    }

    else {
        if (inet_ntop(AF_INET, &sock_clt.sin_addr, dst, INET_ADDRSTRLEN) == NULL) {
            perror("Socket error\n");
            exit (4);
        }

        clt_port = ntohs(sock_clt.sin_port);
        printf("Establishing connection for : %s:%d\n", dst, clt_port);

        // Rename the file by the date of
        bzero(filename, 256);
        intps = time(NULL);
        tmi = localtime(&intps);
        bzero(filename, 256);
        sprintf(filename,"clt.%d.%d.%d.%d.%d.%d", tmi->tm_mday, tmi->tm_mon+1, 1900+tmi->tm_year, tmi->tm_hour, tmi->tm_min, tmi->tm_sec);
        printf("Creating the received file : %s\n",filename);

        if ((fd = open(filename, O_CREAT|O_WRONLY, 0600)) == -1)
        {
            perror("Fail to open file\n");
            exit (3);
        }

        bzero(buffer, BUFFERT);

        n = recv(nsid, buffer, BUFFERT, 0);

        while(n) {
            if ( n == -1) {
                perror("Fail to receive\n");
                exit(5);
            }

            if (( m = write(fd, buffer, n)) == -1) {
                perror("Fail to write file\n");
                exit (6);
            }

            count = count + m;

            bzero(buffer, BUFFERT);

            n = recv(nsid, buffer, BUFFERT, 0);
        }

        close(sfd);
        close(fd);

    }

    close(nsid);

    printf("The transmission was successful: %s.%d\n", dst, clt_port);
    printf("Number of bytes received: %ld \n", count);

    return EXIT_SUCCESS;
}


int create_server_socket (int port){
    int l;
	int sfd;
    int yes = 1;

	sfd = socket(PF_INET,SOCK_STREAM,0);
	if (sfd == -1){
        perror("Socket fail\n");
        return EXIT_SUCCESS;
	}

    if(setsockopt(sfd, SOL_SOCKET, SO_REUSEADDR, &yes, sizeof(int)) == -1 ) {
        perror("Setsockopt error\n");
        exit(5);
    }

    //Socket address destination
	l = sizeof(struct sockaddr_in);

    bzero(&sock_serv,l);

	sock_serv.sin_family = AF_INET;
	sock_serv.sin_port = htons(port);
	sock_serv.sin_addr.s_addr = htonl(INADDR_ANY);

	//Socket identity
	if(bind(sfd, (struct sockaddr*)&sock_serv, l) == -1) {
		perror("Bind fail\n");
		return EXIT_FAILURE;
	}

    return sfd;
}
