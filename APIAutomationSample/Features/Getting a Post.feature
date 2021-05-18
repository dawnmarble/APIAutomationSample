Feature: Get Posts
 In order to make sure I can interact with Posts via the JSONPlaceholder API
 As a consumer of this API
 I want to be sure I am able to receive the correct response when I send a GET request

@Smoke-HappyPath
Scenario: Can GET all Posts
	Given GET all Posts
	Then the response should be a 200 ("OK") response
	And the response body should not be empty

Scenario: Can GET a Post with a parameter
	Given I execute a 'GET' Post where PostId is <value>
	Then the response should be a 200 ("OK") response


	Examples:
	| value |
	| 1     |
	| 98    |