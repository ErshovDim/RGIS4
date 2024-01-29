




List<double> list = new List<double> ();
List<double> list1 = new List<double> { 42 };


string Modus(List<double> list)
{
    // group by value and count frequency
    var query = from i in list
                group i by i into g
                select new { g.Key, Count = g.Count() };

    // compute the maximum frequency
    int max = query.Max(g => g.Count);
    IEnumerable<double> modes = query.Where(g => g.Count == max).Select(g => g.Key);

    int stevec = 1;
    string line = "";
    
    foreach (var item in modes)
    {
        line += " Modus #" + stevec + ": " + item + "\n";
        stevec++;
    }
    return line;
}


string Povprecna(List<double> list)
{
    //double stevilo = 0;
    //foreach (var item in list)
    //    stevilo += item;

    //stevilo = stevilo / list.Count;    ///

    return Convert.ToString(list1.Average());


}


string Mediana(List<double> list)
{
    var sortedList = list.OrderBy(n => n); //sorting 

    double median;
    if (sortedList.Count() % 2 == 0)
    {
        int middleIndex = sortedList.Count() / 2;
        median = (sortedList.ElementAt(middleIndex - 1) + sortedList.ElementAt(middleIndex)) / 2;
    }
    else
    {
        int middleIndex = sortedList.Count() / 2;
        median = sortedList.ElementAt(middleIndex);
    }
    return Convert.ToString(median);

}

string Odklon(List<double> list)
{
    // Compute the average.     
    double avg = list.Average();

    // Perform the Sum of (value-avg)_2_2.      
    double sum = list.Sum(d => Math.Pow(d - avg, 2));


    // Put it all together.      
    return Convert.ToString(Math.Sqrt((sum) / (list.Count())));

}

string Razpon(List<double> list)
{
    var sortedList = list.OrderBy(n => n);
        return Convert.ToString(sortedList.ElementAt(sortedList.Count() -1) - sortedList.ElementAt(0));

}


Console.WriteLine(Razpon(list1));