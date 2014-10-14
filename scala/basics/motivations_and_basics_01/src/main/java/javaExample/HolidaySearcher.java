package javaExample;

import javaExample.Holiday;

import java.util.List;

public interface HolidaySearcher {
    List<Holiday> searchForHolidays(String keyword);
}

