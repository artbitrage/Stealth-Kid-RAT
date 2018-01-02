
/************************************
|               Client              |
*************************************

Codename: Alhpa (Concept)
Function: File Transfer (UDP)

Copyright (c) 2017 Syafiq Hadzir (Alexandrov)
*************************************/

#include <stdio.h>
#include <stdlib.h>

// Time function, sockets, htons... file stat
#include <sys/time.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/uio.h>
#include <sys/stat.h>

// File function and bzero
#include <fcntl.h>
#include <unistd.h>
#include <strings.h>

// Size of buffer used to send file
#define BUFFERT 512

// Functions declaration
int duration (struct timeval *start,struct timeval *stop, struct timeval *delta);
int create_client_socket (int port, char* ipaddr);

struct sockaddr_in sock_serv;

int main (int argc, char *argv[]) {

	struct timeval start, stop, delta;
	int sfd, fd;
	char buf[BUFFERT];

	off_t count = 0, m, sz;

	long int n;
	int l = sizeof(struct sockaddr_in);
	struct stat buffer;

	if (argc != 4) {

		printf("Error usage : %s <ip_serv> <port_serv> <filename>\n",argv[0]);

		return EXIT_FAILURE;
	}

	sfd = create_client_socket(atoi(argv[2]), argv[1]);

	if ((fd = open(argv[3], O_RDONLY)) == -1) {

		perror("Open failed.\n");

		return EXIT_FAILURE;
	}

	//Size of File
	if (stat(argv[3], &buffer) == -1) {

		perror("Stat failed.\n");

		return EXIT_FAILURE;
	}

	else

	sz=buffer.st_size;

	//Transmission preparation
	bzero(&buf, BUFFERT);
	gettimeofday(&start, NULL);

	n = read(fd, buf, BUFFERT);

	while(n) {
		if (n == -1) {
			perror("Read failed.\n");

			return EXIT_FAILURE;
		}

		m = sendto(sfd, buf, n, 0, (struct sockaddr*)&sock_serv, l);
		if (m == -1) {
			perror("Send error.\n");

			return EXIT_FAILURE;
		}

		count += m;

		bzero(buf,BUFFERT);

		n = read(fd, buf, BUFFERT);
	}

	//To unblock the server
	m = sendto(sfd, buf, 0, 0, (struct sockaddr*)&sock_serv, l);

	gettimeofday(&stop, NULL);
	duration(&start, &stop, &delta);

	printf("Number of bytes transfered : %lld\n", count);
	printf("Total of size transfered : %lld\n", sz);
	printf("Estimated transfer duration : %ld.%d \n", delta.tv_sec, delta.tv_usec);

	close(sfd);
	close(fd);

	return EXIT_SUCCESS;
}

/* Time estimation calculation */
int duration (struct timeval *start, struct timeval *stop, struct timeval *delta)
{
	suseconds_t microstart, microstop, microdelta;

	microstart = (suseconds_t) (100000*(start->tv_sec))+ start->tv_usec;
	microstop = (suseconds_t) (100000*(stop->tv_sec))+ stop->tv_usec;
	microdelta = microstop - microstart;

	delta->tv_usec = microdelta%100000;
	delta->tv_sec = (time_t)(microdelta/100000);

	if((*delta).tv_sec < 0 || (*delta).tv_usec < 0)
	return -1;
	else
	return 0;
}

/* Enabling socket creation function */

int create_client_socket (int port, char* ipaddr) {
	int l;
	int sfd;

	sfd = socket(AF_INET, SOCK_DGRAM, 0);

	if (sfd == -1) {

		perror("Socket failed.\n");

		return EXIT_FAILURE;
	}

	// Socket address destination preparation
	l = sizeof(struct sockaddr_in);

	bzero(&sock_serv, l);

	sock_serv.sin_family = AF_INET;
	sock_serv.sin_port = htons(port);

	if (inet_pton(AF_INET, ipaddr, &sock_serv.sin_addr) == 0) {

		printf("Invalid IP address\n");

		return EXIT_FAILURE;
	}

	return sfd;
}
