class SignInRequest {
  final String username;
  final String password;

  SignInRequest({
    required this.username,
    required this.password,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'Email': username,
      'Password': password,
    };
  }
}
