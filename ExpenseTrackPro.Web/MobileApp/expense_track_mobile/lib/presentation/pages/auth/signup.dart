import 'package:expense_track_mobile/components/my_textfield.dart';
import 'package:expense_track_mobile/data/models/signup_request.dart';
import 'package:expense_track_mobile/domain/usecases/signup_use_case.dart';
import 'package:expense_track_mobile/presentation/pages/auth/signin.dart';
import 'package:expense_track_mobile/presentation/service_lokator.dart';
import 'package:flutter/material.dart';

class SignUp extends StatelessWidget {
  SignUp({super.key});

  final usernameController = TextEditingController();
  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  final firstNameController = TextEditingController();
  final lastNameController = TextEditingController();

  final SignUpUseCase signUpUseCase = sl<SignUpUseCase>();

  void signUserUp(BuildContext context) async {
    final result = await signUpUseCase.execute(SignUpRequest(
      username: usernameController.text,
      password: passwordController.text,
      email: emailController.text,
      firstName: firstNameController.text,
      lastName: lastNameController.text,
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
          MaterialPageRoute(builder: (context) => SignIn()),
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color(0xFFFFF6E5),
        appBar: AppBar(
          backgroundColor: const Color(0xFFFFF6E5),
          elevation: 0,
        ),
        body: SafeArea(
            child: Center(
          child: SingleChildScrollView(
              child: Column(
            children: [
              //main text
              Text(
                'Formularz rejestracji użytkownika',
                style: TextStyle(
                  color: Colors.grey[700],
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),

              const SizedBox(height: 50),

              //UserName input
              MyTextField(
                controller: usernameController,
                hintText: 'Username',
                obscureText: false,
              ),

              const SizedBox(height: 10),

              //Email input
              MyTextField(
                controller: emailController,
                hintText: 'E-mail',
                obscureText: false,
              ),

              const SizedBox(height: 10),

              //Password input
              MyTextField(
                controller: passwordController,
                hintText: 'Password',
                obscureText: true,
              ),

              const SizedBox(height: 10),

              //First name input
              MyTextField(
                controller: firstNameController,
                hintText: 'First name',
                obscureText: true,
              ),

              const SizedBox(height: 10),

              //Last name input
              MyTextField(
                controller: lastNameController,
                hintText: 'Last name',
                obscureText: true,
              ),

              const SizedBox(height: 50),

              //Register button
              GestureDetector(
                onTap: () => signUserUp(context),
                child: Container(
                    padding: const EdgeInsets.all(20),
                    margin: const EdgeInsets.symmetric(horizontal: 25),
                    decoration: BoxDecoration(
                      color: Color(0xFF7F3DFF),
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: const Center(
                      child: Text("Zarejestruj się",
                          style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 18,
                          )),
                    )),
              ),
            ],
          )),
        )));
  }
}
