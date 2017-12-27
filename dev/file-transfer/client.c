
/************************************
|               Client              |
*************************************

Codename: Alhpa (Concept)
Function: File Transfer

Copyright (c) 2017 Syafiq Hadzir (Alexandrov)
*************************************/

#include <arpa/inet.h>
#include <unistd.h>

#define SA struct sockaddr

int main (int argc, char *argv[]) {

  int sockfd;
  char fname[25];
  int len;
  struct sockaddr_in servaddr,cliaddr;

  sockfd = socket(AF_INET,SOCK_STREAM,0);

  bzero (&servaddr, sizeof(servaddr));

  servaddr.sin_family = AF_INET;
  servaddr.sin_addr.s_addr = htonl(INADDR_ANY);
  servaddr.sin_port = htons(atoi(argv[1]));

  inet_pton(AF_INET,argv[1], &servaddr.sin_addr);
  connect(sockfd, (SA*)&servaddr, sizeof(servaddr));

  char buffer[100];

  FILE *f;
  f = fopen("testfile.txt", "r");

  fscanf(f,"%s", buffer);
  write(sockfd, buffer, 100);
  printf("The file was succesfully sent.\n");

  return 0;

}
