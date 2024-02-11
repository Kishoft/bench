package main

import (
	"github.com/gofiber/fiber/v2"
	"github.com/gofiber/fiber/v2/middleware/cors"
	"github.com/gofiber/fiber/v2/middleware/logger"

	"github.com/adhtanjung/go_rest_api/database"
	"github.com/adhtanjung/go_rest_api/model"
	_ "github.com/lib/pq"
)

func main() {
	database.Connect()

	app := fiber.New()
	app.Use(logger.New())

	app.Use(cors.New())
	app.Post("/", func(c *fiber.Ctx) error {
		db := database.DB.Db
		user := new(model.User)

		// Store the body in the user and return error if encountered
		if err := c.BodyParser(user); err != nil {
			return c.Status(500).JSON(fiber.Map{"status": "error", "message": "Something's wrong with your input", "data": err})
		}

		err := db.Create(&user).Error
		if err != nil {
			return c.Status(500).JSON(fiber.Map{"status": "error", "message": "Could not create user", "data": err})
		}

		// Return the created user
		return c.Status(201).JSON(fiber.Map{"status": "success", "message": "User has created", "data": user})
	})
	app.Use(func(c *fiber.Ctx) error {
		return c.SendStatus(404) // => 404 "Not Found"
	})

	app.Listen(":3232")
}
