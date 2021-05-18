Feature: Updating Posts
 In order to make sure I can interact with Posts via the JSONPlaceholder API
 As a consumer of this API
 I want to be sure I am able to update a record via a put (and patch?) request


Scenario: Can Update Post with Valid Input
	Given a Update Title Post.json request body
	When I POST the request
	Then the response should be a 201 ("Created") response
	And the response body should be what I expect
