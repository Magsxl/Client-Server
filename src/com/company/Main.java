package com.company;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;
import java.util.Date;

class threads extends Thread {
    BufferedReader streamIn;
    PrintStream streamOut;
    String echo;
    Socket socket;

    public threads(Socket socket) {
        this.socket = socket;
    }

    public void run() {
        try {
            streamIn = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            streamOut = new PrintStream(socket.getOutputStream());
            while ((echo = streamIn.readLine()) != null) {
                Date date = new Date();
                System.out.println(echo);
                System.out.println("Data uzyskania wiadomosci: " + date);
                streamOut.println(new Date());
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

public class Main {
    public static void main(String[] args) {
	Connection();
    }
    public static void Connection() {
        try(ServerSocket serverSocket = new ServerSocket(2000)) {
            while(true) {
                try {
                    Socket socket = serverSocket.accept();
                    System.out.println("Połączono na ip: "+socket.getLocalAddress() +" Port: "+ socket.getPort());
                    threads thread = new threads(socket);
                    thread.start();
                } catch (SocketException e){
                    System.out.println("Brak połączenia");
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}


