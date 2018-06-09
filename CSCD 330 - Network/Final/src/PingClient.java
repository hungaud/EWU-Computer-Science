import java.io.*;
import java.net.*;
import java.text.SimpleDateFormat;
import java.util.*;

public class PingClient {
   private static final int PING = 10;
   private static final int TIMEOUT = 1000; // milliseconds
   private static final int DELAY = 1000; // milliseconds

   private static final double LOSS_RATE = 0.3;
   private static final int AVERAGE_DELAY = 100;  // milliseconds

   public static void main(String[] args) throws Exception {
      // Get command line argument.
      if (args[0] == null) {
         System.out.println("Required arguments: host");
         return;
      } else if (args[1] == null) {
         System.out.println("Required arguments: port");
         return;
      }

      int port = Integer.parseInt(args[1]);
      String host = args[0].toString();

      // Create random number generator for use in simulating
      // packet loss and network delay.
      Random random = new Random();

      // Create a datagram socket for receiving and sending UDP packets
      // through the port specified on the command line.

      //run(host, port);
      //DatagramSocket socket = new DatagramSocket(port);
      //InetAddress address = InetAddress.getLocalHost();

      run(host, port);
   }

   public static void run(String host, int port) {
      InetAddress address;
      DatagramSocket socket;
      try {
         address = InetAddress.getLocalHost();
      } catch (UnknownHostException e) {
         e.printStackTrace();
         return;
      }
      try {
         socket = new DatagramSocket();
         socket.setSoTimeout(TIMEOUT);
      } catch (SocketException e) {
         e.printStackTrace();
         return;
      }

      int seq = 0;
      while(seq != PING) {
         String sendString = printData(seq);
         byte[] sendData = sendString.getBytes();
         DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, address, port);
         try {
            socket.send(sendPacket);
         } catch (IOException e) {
            e.printStackTrace();
         }
         DatagramPacket receiveData = new DatagramPacket(new byte[1024], 1024);
         try {
            socket.receive(receiveData);
         } catch (IOException e) {
            System.err.println("timed out");
         }

         seq++;

         try {
            Thread.sleep(DELAY);
         } catch (InterruptedException e) {
            e.printStackTrace();
         }
      }

   }

/*
      // Processing loop.
      while (true) {
         // Create a datagram packet to hold incomming UDP packet.
         DatagramPacket request = new DatagramPacket(new byte[1024], 1024);

         // Block until the host receives a UDP packet.
         socket.receive(request);

         // Print the recieved data.
         printData(request);

         // Decide whether to reply, or simulate packet loss.
         if (random.nextDouble() < LOSS_RATE) {
            System.out.println("   Reply not sent.");
            continue;
         }

         // Simulate network delay.
         Thread.sleep((int) (random.nextDouble() * 2 * AVERAGE_DELAY));

         // Send reply.
         InetAddress clientHost = request.getAddress();
         int clientPort = request.getPort();
         byte[] buf = request.getData();
         DatagramPacket reply = new DatagramPacket(buf, buf.length, clientHost, clientPort);
         socket.send(reply);

         System.out.println("   Reply sent.");
      }
   */


   /*
    * Print ping data to the standard output stream.
    */
   private static String printData(int seq) {
      String s = "PING " + (seq) + " ";
      SimpleDateFormat time = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSSZ");
      s += time + " \n";
      return s;

   }
}
