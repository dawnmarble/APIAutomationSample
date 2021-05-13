Feature: Posts
 In order to make sure I can interact with Posts via the JSONPlaceholder API
 As a consumer of this API
 I want to be sure I am able to receive the correct response when I send request

@Smoke-HappyPath
Scenario: Can post valid post
	Given a <happypath> request body
	When I POST the request
	Then the response should be a 201 ("Created") response
	And the response body should be what I expect
	