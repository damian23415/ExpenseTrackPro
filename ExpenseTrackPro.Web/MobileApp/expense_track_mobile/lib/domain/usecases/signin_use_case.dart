import 'package:dartz/dartz.dart';
import 'package:dio/dio.dart';
import 'package:expense_track_mobile/core/constants/api_urls.dart';
import 'package:expense_track_mobile/core/network/dio_client.dart';
import 'package:expense_track_mobile/data/models/signin_request.dart';
import 'package:expense_track_mobile/presentation/service_lokator.dart';

class SignInUseCase {
  Future<Either<String, Response>> execute(SignInRequest signInRequest) async {
    try {
      var response = await sl<DioClient>().post(
        ApiUrls.authenticate,
        data: signInRequest.toMap(),
      );

      if (response.statusCode == 200) {
        return Right(response);
      } else {
        return Left('Failed to sign in');
      }
    } on DioException catch (e) {
      return Left(e.response!.data['message']);
    }
  }
}
