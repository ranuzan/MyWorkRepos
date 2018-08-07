#include "Game.h"

//_________________MU_TEST_________________
/*test read write user file ok*/
MU_TEST(test_users_file)
{
	//Arrange
	User *test = usersFileToStruct();
	int size = findNumOfUsers();
	//Act
	int result = usersStructToFile(test, size);//should return 1
	//Assert
	mu_check(result == 1);
	free(test);
}
/*READ WRITE question file*/
MU_TEST(test_question_file)
{
	//Arrange
	Question *test=questionFileToStruct();
	int size = findNumofQuestion();
	//Act
	int result = questionArrayToFile(test, size); //should return 1
	//Assert
	mu_check(result == 1);
	free(test);
}
MU_TEST(test_num_of_question)
{

	//Arrange

	//Act
	int result = findNumofQuestion();
	//Assert
	mu_assert(result >= 30, "Error - Num of questions too small!!!!");
}

/*READ WRITE game setting */
MU_TEST(test_settings)
{
	//Arrange
	GameSettings test = GetSetFromFile();
	//Act
	int result =(test.timeToAnswer>0&&test.lifeSaver%2==0); //time to answer should be bigger then 0 and life saver even result should be 1
	//Assert
	mu_check(result == 1);
}
MU_TEST(test_points)
{
	//Arrange
	GameSettings test = GetSetFromFile();
	int i = 0,result=1;
	//Act
	for (i = 0; i < 10; i++)
		result *= (test.pointsByDifficulty[i] >= 0);
	//result should be 1
	//Assert
	mu_check(result == 1);
}

/*LOGIN tests*/
MU_TEST(test_verifyPassword)
{
	//Arrange
	int result;
	//Act
	result = compereString("abcd", "abcd");	//result should be 1
	//Assert
	mu_check(result == 1);
}
MU_TEST(test_name_exists)
{
	//Arrange
	User *usersArr = usersFileToStruct();
	char name[] = "jonsnow";
	int size = findNumOfUsers();
	//Act
	int result = userNameTest(name, usersArr, size);
	//Assert
	mu_check(result == 0);
	free(usersArr);
}
MU_TEST(test_authenticate)
{
	//Arrange
	User *usersArr = usersFileToStruct();
	char name[] = "liorsh";
	int size = findNumOfUsers();
	//Act
	int result = FindUserIndex(name, usersArr, size);
	//Assert
	mu_check(result == 0);
	free(usersArr);
}

/*INPUT*/
MU_TEST(test_space)
{

	//Arrange
	char x[] = "abc";
	//Act
	int result = spaceTest(x);
	//Assert
	mu_check(result == 1);  
}
MU_TEST(test_premission)
{
	//Arrange
	char x = 'P';
	//Act
	int result = permissionTest(x);
	//Assert
	mu_check(result == 1);

}
MU_TEST(test_input)
{
	//Arrange
	char x = 'A';
	//Act
	int result = Check(x);
	//Assert
	mu_check(result == 1);
}

/*READ WRITE Score*/
MU_TEST(test_score_file)
{
	//Arrange
	int result;
	//Act
	result = AddPlayerScore("test", 50,0);//should return 1

	//Assert
	mu_check(result == 1);
}


//_________________MU_TEST_SUITE_________________
MU_TEST_SUITE(test_question) {
	MU_SUITE_CONFIGURE(NULL, NULL);
	MU_RUN_TEST(test_num_of_question);//question
	MU_RUN_TEST(test_question_file);//question
	MU_REPORT_SUITE();
}
MU_TEST_SUITE(test_Game) {
	MU_SUITE_CONFIGURE(NULL, NULL);
	MU_RUN_TEST(test_input);//game
	MU_RUN_TEST(test_score_file);//score

	MU_REPORT_SUITE();
}
MU_TEST_SUITE(test_user) {
	MU_SUITE_CONFIGURE(NULL, NULL);
	MU_RUN_TEST(test_name_exists);//user
	MU_RUN_TEST(test_space);//user
	MU_RUN_TEST(test_premission);//user
	MU_RUN_TEST(test_users_file);//user
	MU_REPORT_SUITE();
}
MU_TEST_SUITE(test_login) {
	MU_SUITE_CONFIGURE(NULL, NULL);
	MU_RUN_TEST(test_authenticate);//login
	MU_RUN_TEST(test_verifyPassword);//login
	MU_RUN_TEST(test_name_exists);//login
	MU_REPORT_SUITE();
}
MU_TEST_SUITE(test_GameSettings) {
	MU_SUITE_CONFIGURE(NULL, NULL);
	MU_RUN_TEST(test_settings);//game settings
	MU_RUN_TEST(test_points);//game settings
	MU_REPORT_SUITE();

}
//-----------------------------------//
//runs all the test suites in the unit test and gives printed result for an output.
void RunAllUnitTests() {
	MU_RUN_SUITE(test_question);
	MU_RUN_SUITE(test_user);
	MU_RUN_SUITE(test_Game);
	MU_RUN_SUITE(test_GameSettings);
	MU_RUN_SUITE(test_login);
	MU_REPORT();
}