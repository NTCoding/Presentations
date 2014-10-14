package scalaExample

import java.util

// trait - aka interface
trait HolidaySearcher {
  // def = method definition - public by default
  def searchForHolidays(keyword: String): List[Holiday] // return type at the end
}

class ExampleHolidaySearcher extends HolidaySearcher {

  override def searchForHolidays(keyword: String): util.List[Holiday] = {
    // type inference - no need to declare variable type (but you can if you want to)
    var holidays = findHolidays(keyword)
    holidays // no return keyword - last statement is return value
  }

  private def findHolidays(keyword: String) = null

}

// no need for getters and setters - Scala will generate it all from this definition
class Holiday(name: String, phoneNumber: String)


/*
    ***** Equivalent Java *****

    public interface HolidaySearcher {
      List<Holiday> SearchForHolidays(String keyword);
    }

    public class Holiday {

      public String getName() {
          return "";
      }

      public String getPhoneNumber() {
          return "";
      }

      public void setName(String name) { }

      public void setPhoneNumber(String number) {}

    }

    public class ExampleHolidaySearcher implements HolidaySearcher {

      @Override
      public List<Holiday> searchForHolidays(String keyword) {
          List<Holiday> holidays = findHolidays(keyword);
          return holidays;
      }

      private List<Holiday> findHolidays(String keyword) {
          return null;
      }

    }


 */


