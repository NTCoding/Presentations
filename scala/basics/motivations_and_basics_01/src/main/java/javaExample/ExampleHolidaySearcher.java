package javaExample;

import java.util.List;

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
