import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    String dayName = DateFormat.EEEE().format(DateTime.now()).toUpperCase();
    String dayNumber = DateFormat.d().format(DateTime.now());
    String monthName = DateFormat.MMMM().format(DateTime.now()).toUpperCase();

    return Scaffold(
      body: SafeArea(
        child: Column(
          children: [
            Container(
              decoration: BoxDecoration(
                  gradient: LinearGradient(
                colors: [
                  Color(0xFFFFF6E5),
                  Color(0xFFFDF4E2),
                  Color.fromARGB(255, 226, 210, 179),
                ],
                begin: Alignment.topCenter,
                end: Alignment.bottomCenter,
              )),
              child: Padding(
                padding: const EdgeInsets.all(25.0),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          '$dayName $dayNumber',
                          style: TextStyle(
                            fontSize: 18,
                            color: Colors.grey[700],
                          ),
                        ),
                        Text(
                          monthName,
                          style: TextStyle(
                            fontSize: 18,
                            color: Colors.grey[700],
                          ),
                        ),
                      ],
                    ),
                    Text(
                      'Expense Track Pro',
                      style: TextStyle(fontSize: 18, color: Colors.grey[700]),
                    ),
                  ],
                ),
              ),
            ),
            Text('Bilans konta'),
            Text('20 000 zł'),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Column(
                  children: [
                    Text('Wpływy'),
                    Text('10 000 zł'),
                  ],
                ),
                Column(
                  children: [
                    Text('Wydatki'),
                    Text('5 000 zł'),
                  ],
                ),
              ],
            ),
            DefaultTabController(
              initialIndex: 0,
              length: 4,
              child: TabBar(tabs: [
                Tab(text: 'Dziś'),
                Tab(text: 'Tydzień'),
                Tab(text: 'Miesiąc'),
                Tab(text: 'Rok'),
              ]),
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Text('Ostatnie transakcje'),
                Text('Zobacz wszystkie'),
              ],
            ),
          ],
        ),
      ),
    );
  }
}

/*
Column(
      children: [
        Padding(
          padding: const EdgeInsets.all(25.0),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(DateTime.now().toString()),
              Text('Expense Track Pro'),
            ],
          ),
        ),
      ],
    ));
*/
