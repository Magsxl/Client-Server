package com.company;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;
import java.sql.SQLOutput;

public class Main {
    public static void main(String[] args) {
	Connection();
    }
    public static void Connection () {
        try(ServerSocket serverSocket = new ServerSocket(2000)) {
            while(true) {
                try {
                    Socket socket = serverSocket.accept();
                    System.out.println("Połączono na ip: "+socket.getLocalAddress() +" Port: "+ socket.getPort());
                } catch (SocketException e){
                    System.out.println("Brak połączenia");
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}


