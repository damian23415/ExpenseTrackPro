import 'package:expense_track_mobile/components/my_textfield.dart';
import 'package:expense_track_mobile/data/models/signin_request.dart';
import 'package:expense_track_mobile/domain/usecases/signin_use_case.dart';
import 'package:expense_track_mobile/presentation/pages/main_app/home.dart';
import 'package:expense_track_mobile/presentation/pages/auth/signup.dart';
import 'package:expense_track_mobile/presentation/service_lokator.dart';
import 'package:flutter/material.dart';

class SignIn extends StatelessWidget {
  SignIn({super.key});

  //text edditing controller
  final usernameController = TextEditingController();
  final passwordController = TextEditingController();
  final emailController = TextEditingController();

  //useCase
  final SignInUseCase signInUseCase = sl<SignInUseCase>();

  void signUserIn(BuildContext context) async {
    final result = await signInUseCase.execute(SignInRequest(
      username: usernameController.text,
      password: passwordController.text,
    ));

    result.fold(
      (error) => showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: Text(error),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                child: const Text('OK'),
              )
            ],
          );
        },
      ),
      (response) {
        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => HomePage()),
        );
      },
    );
  }

  //view sign up method
  void viewSignUp(BuildContext context) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => SignUp()),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color(0xFFFFF6E5),
        body: SafeArea(
            child: Center(
                child: SingleChildScrollView(
                    child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
          const SizedBox(height: 50),

          //logo
          const Image(
            image: AssetImage(
              'assets/images/logo.png',
            ),
            height: 200,
            width: 200,
          ),

          const SizedBox(height: 50),

          //welcome text
          Text('Witaj w ExpenseTrackPro',
              style: TextStyle(
                color: Colors.grey[700],
                fontSize: 16,
              )),

          const SizedBox(height: 25),

          //username text field
          MyTextField(
            controller: usernameController,
            hintText: 'Login',
            obscureText: false,
          ),

          const SizedBox(height: 10),

          //password text field
          MyTextField(
            controller: passwordController,
            hintText: 'Hasło',
            obscureText: true,
          ),

          const SizedBox(height: 10),

          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 25.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Text(
                  'Nie pamiętasz hasła?',
                  style: TextStyle(
                    color: Colors.grey[600],
                    fontSize: 14,
                  ),
                )
              ],
            ),
          ),

          const SizedBox(height: 10),

          //Signin button
          GestureDetector(
            onTap: () => signUserIn(context),
            child: Container(
                padding: const EdgeInsets.all(20),
                margin: const EdgeInsets.symmetric(horizontal: 25),
                decoration: BoxDecoration(
                  color: Color(0xFF7F3DFF),
                  borderRadius: BorderRadius.circular(8),
                ),
                child: const Center(
                  child: Text("Zaloguj się",
                      style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                      )),
                )),
          ),

          const SizedBox(height: 30),

          // or continue with
          Text('Nie masz konta?',
              style: TextStyle(
                color: Colors.grey[700],
                fontSize: 16,
              )),

          const SizedBox(height: 30),

          GestureDetector(
            onTap: () => viewSignUp(context),
            child: Container(
                padding: const EdgeInsets.all(20),
                margin: const EdgeInsets.symmetric(horizontal: 25),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(8),
                  border: Border.all(color: Colors.black),
                ),
                child: Center(
                  child: Text("Zarejestruj się",
                      style: TextStyle(
                        color: Colors.grey[700],
                        fontSize: 18,
                      )),
                )),
          ),
        ])))));
  }
}
