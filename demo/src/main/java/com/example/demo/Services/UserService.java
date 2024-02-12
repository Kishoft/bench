package com.example.demo.Services;

import java.util.concurrent.CompletableFuture;

import org.springframework.scheduling.annotation.Async;
import org.springframework.stereotype.Service;

import com.example.demo.Models.Pepe;
import com.example.demo.repositories.UserRepository;


@Service
public class UserService {
    private final UserRepository userRepository;

    public UserService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @SuppressWarnings("null")
    @Async
    public CompletableFuture<Pepe> saveUser(Pepe pepe) {
        Pepe newPepe =  userRepository.save(pepe);
        return CompletableFuture.completedFuture(newPepe);

    }
}
