import 'package:expense_track_mobile/core/network/dio_client.dart';
import 'package:expense_track_mobile/data/source/auth_api_service.dart';
import 'package:expense_track_mobile/domain/usecases/signin_use_case.dart';
import 'package:expense_track_mobile/domain/usecases/signup_use_case.dart';
import 'package:get_it/get_it.dart';

final sl = GetIt.instance;

void setupServiceLocator() {
  sl.registerSingleton<DioClient>(DioClient());

  //Service
  sl.registerSingleton<AuthApiService>(AuthApiServiceImpl());

  //UseCases
  sl.registerSingleton<SignInUseCase>(SignInUseCase());
  sl.registerSingleton<SignUpUseCase>(SignUpUseCase());
}
