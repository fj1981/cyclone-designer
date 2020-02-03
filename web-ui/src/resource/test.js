let test_str = `
{
	"variable": [
		{
			"lineNumber": 5,
			"dirty": false,
			"name": "var3",
			"value": "ok",
			"modify": 3
		},
		{
			"lineNumber": 3,
			"dirty": false,
			"name": "var2",
			"value": "ok",
			"modify": 3
		},
		{
			"lineNumber": 2,
			"dirty": false,
			"name": "var1",
			"value": "jiangheng",
			"modify": 1
		}
	],
	"call": {
		"lineNumber": 1,
		"serial": "",
		"modify": 2,
		"dirty": false,
		"type": 10,
		"expr": [
			{
				"lineNumber": 4,
				"serial": "process1",
				"modify": 2,
				"dirty": false,
				"rect": [{"bottom":2280,"left":0,"right":1080,"top":0}],
				"type": 1,
				"input": [],
				"output": [
					"var2"
				]
			},
			{
				"lineNumber": 6,
				"serial": "process2",
				"modify": 2,
				"dirty": false,
				"rect": [{"bottom":2280,"left":0,"right":1080,"top":0}],
				"type": 2,
				"input": [
					"var1"
				],
				"output": [
					"var3"
				]
			}
		]
	}
}
`

export {test_str}