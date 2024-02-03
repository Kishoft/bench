package com.example.demo.controllers;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.scheduling.annotation.Async;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.demo.Models.Pepe;
import com.example.demo.Services.UserService;
import com.example.demo.repositories.UserRepository;

import jakarta.validation.Valid;

@RestController
@RequestMapping("/tttt")
public class UserController {

    private final UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    @SuppressWarnings("null")
    @PostMapping()
    @Async
    public ResponseEntity<?> addUser(@Valid @RequestBody  Pepe user) {
            userService.saveUser(user);
            return ResponseEntity.noContent().build();
    }

    @GetMapping()
    public String showSignUpForm() {
        return "ta";
    }

}
