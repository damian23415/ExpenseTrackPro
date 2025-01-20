import 'package:dartz/dartz.dart';
import 'package:dio/dio.dart';
import 'package:expense_track_mobile/core/constants/api_urls.dart';
import 'package:expense_track_mobile/core/network/dio_client.dart';
import 'package:expense_track_mobile/data/models/signin_request.dart';
import 'package:expense_track_mobile/data/models/signup_request.dart';
import 'package:expense_track_mobile/presentation/service_lokator.dart';

abstract class AuthApiService {
  Future<Either> signin(SignInRequest signupReq);
  Future<Either> signup(SignUpRequest signupReq);
}

class AuthApiServiceImpl extends AuthApiService {
  @override
  Future<Either> signin(SignInRequest signupReq) async {
    try {
      var response = await sl<DioClient>().post(
        ApiUrls.authenticate,
        data: signupReq.toMap(),
      );

      return Right(response);
    } on DioException catch (e) {
      return Left(e.response!.data['message']);
    }
  }

  @override
  Future<Either> signup(SignUpRequest signupReq) async {
    try {
      var response = await sl<DioClient>().post(
        ApiUrls.authenticate,
        data: signupReq.toMap(),
      );

      return Right(response);
    } on DioException catch (e) {
      return Left(e.response!.data['message']);
    }
  }
}
