Feature: Deleting a Post
 In order to make sure I can delete Posts via the JSONPlaceholder API
 As a consumer of this API
 I want to be sure I am able to request a valid deletion and the deletion is successful

@Smoke-HappyPath
Scenario: Deleting a Post
	Given I execute a 'DELETE' Post where PostId is 1
	Then the response should be a 200 ("OK") response