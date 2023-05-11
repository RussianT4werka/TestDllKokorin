using SF2022User01Lib;

namespace TestDllKokorin
{
    public class Tests
    {
        Calculations calculations;
        [SetUp]
        public void Setup()
        {
            calculations = new Calculations();
        }

        [Test]
        public void TestComparisonOfIncomingAndOutgoingParameters30Min()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] {new TimeSpan(10,0,0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40};
            TimeSpan beginWorkingTime = new TimeSpan(8,0,0);
            TimeSpan endWorkingTime = new TimeSpan(18,0,0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30",
                                             "08:30 - 09:00",
                                             "09:00 - 09:30",
                                             "09:30 - 10:00",
                                             "11:30 - 12:00",
                                             "12:00 - 12:30",
                                             "12:30 - 13:00",
                                             "13:00 - 13:30",
                                             "13:30 - 14:00",
                                             "14:00 - 14:30",
                                             "14:30 - 15:00",
                                             "15:40 - 16:10",
                                             "16:10 - 16:40",
                                             "17:30 - 18:00"};
            Assert.AreEqual(result, strings);
        }

        [Test]
        public void TestComparisonOfIncomingAndOutgoingParameters40Min()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] {
                new TimeSpan(10, 0, 0), 
                new TimeSpan(11, 0, 0), 
                new TimeSpan(15, 0, 0), 
                new TimeSpan(15, 30, 0), 
                new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 40;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:40",
                                             "08:40 - 09:20",
                                             "09:20 - 10:00",
                                             "11:30 - 12:10",
                                             "12:10 - 12:50",
                                             "12:50 - 13:30",
                                             "13:30 - 14:10",
                                             "14:10 - 14:50",                                            
                                             "15:40 - 16:20",};
            Assert.AreEqual(result, strings);
        }

        [Test]
        public void TestComparisonOfIncomingAndOutgoingParameters30MinEditDurationsAndStartTimes()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] {new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30",
                                             "08:30 - 09:00",
                                             "09:00 - 09:30",
                                             "09:30 - 10:00",
                                             "10:00 - 10:30",
                                             "10:30 - 11:00",
                                             "11:30 - 12:00",
                                             "12:00 - 12:30",
                                             "12:30 - 13:00",
                                             "13:00 - 13:30",
                                             "13:30 - 14:00",
                                             "14:00 - 14:30",
                                             "14:30 - 15:00",
                                             "15:40 - 16:10",
                                             "16:10 - 16:40",
                                             "17:30 - 18:00",};
            Assert.AreEqual(result, strings);
        }

        [Test]
        public void TestNegativeTime()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = -30;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestDateStartMoreDateEnd()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(18, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 0, 0);
            int consultationTime = 30;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestNoExeption()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            Assert.DoesNotThrow(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestFalseWrongPeriods()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 60, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30",
                                             "08:30 - 09:00",
                                             "09:00 - 09:30",
                                             "09:30 - 10:00",
                                             "10:00 - 10:30",
                                             "10:30 - 11:00",
                                             "11:30 - 12:00",
                                             "12:00 - 12:30",
                                             "12:30 - 13:00",
                                             "13:00 - 13:30",
                                             "13:30 - 14:00",
                                             "14:00 - 14:30",
                                             "14:30 - 15:00",
                                             "15:40 - 16:10",
                                             "16:10 - 16:40",
                                             "17:30 - 18:00",};

            Assert.That(strings, Is.Not.EqualTo(result));
        }

        [Test]
        public void TestMaxConsTime()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 300;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestMissingPeriods()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 60, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30",
                                             "08:30 - 09:00",
                                             "09:00 - 09:30",
                                             "09:30 - 10:00",
                                             "10:00 - 10:30",
                                             "10:30 - 11:00",
                                             "11:30 - 12:00",
                                             "12:00 - 12:30",
                                             "12:30 - 13:00",
                                             "13:00 - 13:30",
                                             "13:30 - 14:00",
                                             "14:00 - 14:30",
                                             "14:30 - 15:00"};

            Assert.That(strings, Is.Not.EqualTo(result));
        }

        [Test]
        public void TestNoEmployment()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 0, 0, 0, 0, 0 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
           
            string[] strings = new string[] {"08:00 - 08:30",
                                             "08:30 - 09:00",
                                             "09:00 - 09:30",
                                             "09:30 - 10:00",
                                             "10:00 - 10:30",
                                             "10:30 - 11:00",
                                             "11:00 - 12:00",
                                             "12:00 - 12:30",
                                             "12:30 - 13:00",
                                             "13:00 - 13:30",
                                             "13:30 - 14:00",
                                             "14:00 - 14:30",
                                             "14:30 - 15:00",
                                             "15:00 - 15:30",
                                             "15:30 - 16:00",
                                             "16:00 - 16:30",
                                             "16:30 - 17:00",
                                             "17:00 - 17:30",
                                             "17:30 - 18:00"};
            Assert.Catch(typeof(ArgumentException), () => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

    }
}