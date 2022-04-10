package com.company;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
	// write your code here
    }
    public static void Connection () {
        try(ServerSocket serverSocket = new ServerSocket(2000)) {
            Socket connSocket = serverSocket.accept();

            InputStream inputStream = connSocket.getInputStream();
            OutputStream outputStream = connSocket.getOutputStream();

            PrintWriter printWriter = new PrintWriter(new OutputStreamWriter(outputStream, "UTF-8"),true);

            printWriter.println("Połączono");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}


