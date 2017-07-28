package s17cs350task1;

import java.io.Serializable;

/**
 * Created by HungA on 4/18/2017.
 */
public class TaskException extends RuntimeException implements Serializable {

   public TaskException() {

   }

   public TaskException(String s) {
      super(s);
   }

}
