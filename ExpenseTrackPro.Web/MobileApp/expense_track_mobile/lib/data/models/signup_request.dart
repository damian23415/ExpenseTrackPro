class SignUpRequest {
  final String username;
  final String password;
  final String email;
  final String firstName;
  final String lastName;

  SignUpRequest({
    required this.username,
    required this.password,
    required this.email,
    required this.firstName,
    required this.lastName,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'UserName': username,
      'Email': email,
      'Password': password,
      'FirstName': firstName,
      'LastName': lastName,
    };
  }
}
