import 'package:dio/dio.dart';

class DioClient {
  final Dio _dio;

  DioClient()
      : _dio = Dio(BaseOptions(
          connectTimeout: Duration(seconds: 10), // 10 seconds
          receiveTimeout: Duration(seconds: 10), // 10 seconds
          headers: {
            'Content-Type': 'application/json',
          },
        )) {
    _dio.interceptors.add(LogInterceptor(responseBody: true));
  }

  Future<Response> post(String url, {dynamic data}) async {
    try {
      final Response response = await _dio.post(url, data: data);
      return response;
    } on DioException catch (e) {
      rethrow;
    }
  }
}
