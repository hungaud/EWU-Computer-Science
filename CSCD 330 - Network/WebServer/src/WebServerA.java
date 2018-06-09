import java.io.* ;
import java.net.* ;
import java.util.* ;

public final class WebServerA {

   public static void main(String argv[]) throws Exception {
      // Set the port number.
      int port = 6789;

      // Establish the listen socket.
	       ServerSocket listener = new ServerSocket(port);

      // Process HTTP service requests in an infinite loop.
      while (true) {
         // Listen for a TCP connection request.
         Socket connection = listener.accept();
         // Construct an object to process the HTTP request message.
         HttpRequest request = new HttpRequest(connection);

         // Create a new thread to process the request.
         Thread thread = new Thread(request);

         // Start the thread.
         thread.start();

      }
   }
}

// does the http request and only handles the request.
final class HttpRequest implements Runnable {
   final static String CRLF = "\r\n";
   Socket socket;

   // Constructor
   public HttpRequest(Socket socket) throws Exception {
      this.socket = socket;
   }

   // Implement the run() method of the Runnable interface.
   public void run() {
      try {
         processRequest();
      } catch (Exception e) {
         System.out.println(e.toString());
      }
   }

   // process the request. it'll only handle the request. and give a response
   // (get host connection etc.)
   private void processRequest() throws Exception {
      // Get a reference to the socket's input and output streams.
      InputStream is = socket.getInputStream();
      DataOutputStream os = new DataOutputStream(socket.getOutputStream());

      // Set up input stream filters.

      BufferedReader br = new BufferedReader(new InputStreamReader(is));
      // Get the request line of the HTTP request message.
      String requestLine = br.readLine();

      // Display the request line.
      System.out.println();
      System.out.println(requestLine);
      // Get and display the header lines.
      String headerLine = null;
      while ((headerLine = br.readLine()).length() != 0) {
         System.out.println(headerLine);
      }
      // Close streams and socket.
      os.close();
      br.close();
      socket.close();


   }

}